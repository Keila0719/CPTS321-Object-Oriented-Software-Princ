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
        /// Initializes the base with the operator -.
        /// </summary>
        public SubtractionNode()
            : base('-')
        {
        }

        /// <summary>
        /// Gets the operator character for this node.
        /// Referenced the following to understand how to do it:
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading.
        /// </summary>
        public override char Operator => '-';

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
