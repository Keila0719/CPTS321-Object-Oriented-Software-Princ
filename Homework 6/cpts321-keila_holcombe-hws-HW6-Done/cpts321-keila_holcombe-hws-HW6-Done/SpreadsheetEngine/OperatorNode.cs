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
        /// The node that stores the current node's left subtree.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected Node? left;
#pragma warning restore SA1401

        /// <summary>
        /// The node that stores the current node's right subtree.
        /// </summary>
#pragma warning disable SA1401 // Assignment requires protected field
        protected Node? right;
#pragma warning restore SA1401

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
        public Node? Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// Gets or sets references the right node of the tree and allow to get and set the node.
        /// </summary>
        public Node? Right
        {
            get
            {
                return this.right;
            }

            set
            {
                this.right = value;
            }
        }
    }
}
