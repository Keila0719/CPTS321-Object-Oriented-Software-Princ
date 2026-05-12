// <copyright file="ConstantNode.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Deals with when the nodes are a constand numerical value.
    /// </summary>
    public class ConstantNode : Node
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value"> New value that is stored into the Value variable.</param>
        public ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets access the value variable by getting and setting their value.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Evaluates the value of what the constant node is refering and return that value.
        /// </summary>
        /// <returns> Current value of the constantNode.</returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
