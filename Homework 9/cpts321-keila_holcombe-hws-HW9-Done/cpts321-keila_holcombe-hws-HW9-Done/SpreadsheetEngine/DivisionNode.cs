// <copyright file="DivisionNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with when the nodes are dividing it's right and left subtrees.
    /// </summary>
    internal class DivisionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// Initializes the base by storing the character of operators '/'.
        /// </summary>
        /// <param name="operators"> character of the operator. </param>
        public DivisionNode()
            : base('/')
        {
        }

        /// <summary>
        /// Gets the operator character for this node.
        /// Referenced the following to understand how to do it:
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading.
        /// </summary>
        public override char Operator => '/';

        /// <summary>
        /// Evaluates the expression of when the OperatorNode is division.
        /// </summary>
        /// <returns> The value of the expression.</returns>
        public override double Evaluate()
        {
            if (this.Left is null || this.Right is null)
            {
                throw new InvalidOperationException("We will need both left and right node");
            }

            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
