// <copyright file="CircularReferenceException.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This exception is thrown when there is a circular reference in the cell.
    /// Referenced class powerpoint.
    /// </summary>
    public class CircularReferenceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircularReferenceException"/> class.
        /// Initialize a new instance of the exception.
        /// </summary>
        public CircularReferenceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularReferenceException"/> class.
        /// This will initialize the circular reference exception with a specific message.
        /// </summary>
        /// <param name="message"> The current exception message.</param>
        public CircularReferenceException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularReferenceException"/> class.
        /// Initialize the exception with the message and the inner exception.
        /// </summary>
        /// <param name="message"> The current exception message.</param>
        /// <param name="inner"> The inner exception.</param>
        public CircularReferenceException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
