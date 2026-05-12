// <copyright file="InvalidExpressionException.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// The exception that is thrown when there is a invalid expression.
    /// Referenced class powerpoint.
    /// </summary>
    public class InvalidExpressionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidExpressionException"/> class.
        /// Initializes the exception.
        /// </summary>
        public InvalidExpressionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidExpressionException"/> class.
        /// Initializes the exception with a message.
        /// </summary>
        /// <param name="message">The specific message.</param>
        public InvalidExpressionException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidExpressionException"/> class.
        /// Initializes the exception with a message and ineer exception.
        /// </summary>
        /// <param name="message"> The specific message.</param>
        /// <param name="inner"> The inner exception.</param>
        public InvalidExpressionException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
