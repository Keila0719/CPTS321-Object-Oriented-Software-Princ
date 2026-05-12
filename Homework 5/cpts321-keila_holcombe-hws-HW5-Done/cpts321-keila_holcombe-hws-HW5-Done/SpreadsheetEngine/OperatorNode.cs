// <copyright file="OperatorNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Provides outline for the add, sub, mul, and div nodes and becomes the base for them.
    /// </summary>
    public abstract class OperatorNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="c"> New character of the operation that is stored in the Operator.</param>
        public OperatorNode(char c)
        {
            this.Operator = c;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets stores the operator char like +, -, *, /, etc by setting and getting the variable.
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Gets or sets references the left node of the tree and allow to get and set the node.
        /// </summary>
        public Node? Left { get; set; }

        /// <summary>
        /// Gets or sets references the right node of the tree and allow to get and set the node.
        /// </summary>
        public Node? Right { get; set; }
    }
}
