// <copyright file="OperatorNodeFactory.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Manages different cells and creating the cells from the information given.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Create a operator node for each type of operator.
        /// </summary>
        /// <param name="operators"> character of operator.</param>
        /// <returns>The node of the new created node for that operator.</returns>
        /// <exception cref="NotSupportedException"> If there are other operator, return a exception.</exception>
        public OperatorNode CreateOperatorNode(char operators)
        {
            // Check which operator it is and create a node for it.
            switch (operators)
            {
                case '+':
                    return new AdditionNode(operators);
                case '-':
                    return new SubtractionNode(operators);
                case '*':
                    return new MultiplicationNode(operators);
                case '/':
                    return new DivisionNode(operators);
                default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + operators.ToString() + " not supported.");
            }
        }
    }
}