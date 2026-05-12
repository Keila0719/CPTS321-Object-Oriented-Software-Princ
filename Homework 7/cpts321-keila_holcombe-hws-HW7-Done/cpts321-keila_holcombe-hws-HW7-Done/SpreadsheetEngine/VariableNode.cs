// <copyright file="VariableNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with when the nodes that is referencing a variable and allow to store that variable name and access that value.
    /// </summary>
    public class VariableNode : Node
    {
        /// <summary>
        /// Gets the reference of the expressionTree object.
        /// </summary>
        private ExpressionTree expressionTree;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name"> New name of the variable that is stored into the Name variable.</param>
        /// <param name="tree"> Access the expressionTree.</param>
        public VariableNode(string name, ExpressionTree tree)
        {
            this.Name = name;
            this.expressionTree = tree;
        }

        /// <summary>
        /// Gets or sets allow access to the name variable by getting and setting the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Evaluates the current variable node by accessing the dictionary and searching for the name of the variable.
        /// Referenced the below link to find how to check if a certain key exists in a dictionary:
        /// https://www.geeksforgeeks.org/c-sharp/c-sharp-dictionary-containskey-method/.
        /// Referenced the below link to get an idea of how to access the dictionary:
        /// https://stackoverflow.com/questions/55442323/check-if-there-is-a-given-string-in-a-dictionary.
        /// </summary>
        /// <param name="variables"> The variable dictionary that is storing the expression.</param>
        /// <returns> Current value of the constantNode.</returns>
        public override double Evaluate()
        {
            // Get the current dictionary
            Dictionary<string, double> current = this.expressionTree.GetVariable();

            // Check if that the variable name position has a value, if yes return that value
            if (current.TryGetValue(this.Name, out double value))
            {
                return value;
            }

            // If it doesn't have a value set for that position, return 0
            return 0;
        }
    }
}
