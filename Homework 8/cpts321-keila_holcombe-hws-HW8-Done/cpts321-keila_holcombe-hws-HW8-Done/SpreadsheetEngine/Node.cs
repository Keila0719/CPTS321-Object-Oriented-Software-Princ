// <copyright file="Node.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using static SpreadsheetEngine.Node;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Provides the outline of what the other nodes are supposed to contain.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Outline of the evaluate method so the other node class which is referencing this class can create and use.
        /// </summary>
        /// <returns> Evaluated value of the expression.</returns>
        public abstract double Evaluate();
    }
}