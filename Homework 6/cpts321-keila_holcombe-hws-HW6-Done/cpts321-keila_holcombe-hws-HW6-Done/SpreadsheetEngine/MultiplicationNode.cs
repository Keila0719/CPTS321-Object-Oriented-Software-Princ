// <copyright file="MultiplicationNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with when the nodes are multiplying each other.
    /// </summary>
    internal class MultiplicationNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationNode"/> class.
        /// Initializes the base by storing the character of operator that will store '*'.
        /// </summary>
        /// <param name="operators"> character of the operator.</param>
        public MultiplicationNode(char operators)
            : base(operators)
        {
        }

        /// <summary>
        /// Evaluates the expression of when the OperatorNode is a multiplication.
        /// </summary>
        /// <returns>Evaluated value of the expression.</returns>
        public override double Evaluate()
        {
            if (this.Left is null || this.Right is null)
            {
                throw new InvalidOperationException("We will need both left and right node");
            }

            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}
