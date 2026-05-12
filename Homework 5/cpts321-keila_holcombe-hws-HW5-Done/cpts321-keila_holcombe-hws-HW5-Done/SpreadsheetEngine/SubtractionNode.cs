// <copyright file="SubtractionNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with when the classes are subtracting each other.
    /// </summary>
    internal class SubtractionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// Initializes the base with the operators.
        /// </summary>
        /// <param name="operators"> character of the current operator.</param>
        public SubtractionNode(char operators)
            : base(operators)
        {
        }

        /// <summary>
        /// Evaluates the expression when the Operatornode is a subtraction.
        /// </summary>
        /// <returns>Evaluated value of the expression.</returns>
        public override double Evaluate()
        {
            if (this.Left is null || this.Right is null)
            {
                throw new InvalidOperationException("We will need both left and right node");
            }

            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}
