// <copyright file="OperatorNodeFactory.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.Reflection;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Manages different cells and creating the cells from the information given.
    /// This class was mostly referencing the in class code that was given from Venera.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Stores the dictionary of operator by keeping the character of that operator and that type.
        /// </summary>
        private Dictionary<char, Type> operators = new Dictionary<char, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// Initializes the new operator factory.
        /// </summary>
        public OperatorNodeFactory()
        {
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        /// <summary>
        /// This will understand which operation needs to happen with the type.
        /// </summary>
        /// <param name="op"> THe character that represent the current operator.</param>
        /// <param name="type"> The type of node the current operator is.</param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// Create a operator node for each type of operator.
        /// </summary>
        /// <param name="op"> character of operator.</param>
        /// <returns>The node of the new created node for that operator.</returns>
        /// <exception cref="NotSupportedException"> If there are other operator, return a exception.</exception>
        public OperatorNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object? operatorNodeObject = System.Activator.CreateInstance(this.operators[op]);

                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }

            throw new Exception("Unhandled operator");
        }

        /// <summary>
        /// THis will get the subclasses of operator node and understand which evaluation will happen depending on which onOperator is inputted.
        /// </summary>
        /// <param name="onOperator"> Represents which operator is needed to be done.</param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            // get the type declaration of OperatorNode
            Type operatorNodeType = typeof(OperatorNode);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our OperatorNode class using LINQ
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                // Iterate over those subclasses of OperatorNode
                foreach (var type in operatorTypes)
                {
                    var op = type.GetProperty("Operator");

                    if (op != null)
                    {
                        // for each subclass, retrieve the Operator property
                        PropertyInfo operatorField = op;

                        if (operatorField != null)
                        {
                            // Get the character of the Operator
                            object? instance = Activator.CreateInstance(type);
                            object? value = operatorField.GetValue(instance);

                            // If “Operator” property is not static, you will need to create
                            // an instance first and use the following code instead (or similar):
                            // object value = operatorField.GetValue(Activator.CreateInstance(type,
                            // new ConstantNode(0)));
                            if (value is char)
                            {
                                char operatorSymbol = (char)value;

                                // And invoke the function passed as parameter
                                // with the operator symbol and the operator class
                                onOperator(operatorSymbol, type);
                            }
                        }
                    }
                }
            }
        }
    }
}