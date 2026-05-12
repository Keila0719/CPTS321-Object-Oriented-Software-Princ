// <copyright file="SelfReferenceException.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This exception is thrown when there is a self reference in the cell.
    /// Referenced class powerpoint.
    /// </summary>
    public class SelfReferenceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelfReferenceException"/> class.
        /// Initialize a new instance of the exception.
        /// </summary>
        public SelfReferenceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfReferenceException"/> class.
        /// This will initialize the self reference exception with a specific message.
        /// </summary>
        /// <param name="message"> The current exception message.</param>
        public SelfReferenceException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfReferenceException"/> class.
        /// Initialize the exception with the message and the inner exception.
        /// </summary>
        /// <param name="message"> The current exception message.</param>
        /// <param name="inner"> The inner exception.</param>
        public SelfReferenceException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}