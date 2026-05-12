// <copyright file="AdditionNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with the situation of when the nodes are adding together.
    /// </summary>
    internal class AdditionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// Initializes the base operator by the char operator which is '+'.
        /// </summary>
        /// <param name="operators"> character of the current operator.</param>
        public AdditionNode(char operators)
            : base(operators)
        {
        }

        /// <summary>
        /// Evaluates the expression when the operatorNode stores an addition.
        /// </summary>
        /// <returns> Value of the evaluated number of expression.</returns>
        public override double Evaluate()
        {
            if (this.Left is null || this.Right is null)
            {
                throw new InvalidOperationException("We will need both left and right node");
            }

            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
