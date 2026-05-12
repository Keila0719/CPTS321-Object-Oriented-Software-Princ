// <copyright file="InvalidTypeException.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// The exception that is thrown when there is a invalid type.
    /// Referenced class powerpoint.
    /// </summary>
    public class InvalidTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// Initializes the exception.
        /// </summary>
        public InvalidTypeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// Initializes the exception with a message.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidTypeException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeException"/> class.
        /// Initializes the exception with a message and inner exception.
        /// </summary>
        /// <param name="message"> The specific message.</param>
        /// <param name="inner">The inner exception.</param>
        public InvalidTypeException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
