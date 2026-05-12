// <copyright file="InvalidCellReferenceException.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This exception is thrown when there is a invalid reference in the cell.
    /// Referenced class powerpoint.
    /// </summary>
    public class InvalidCellReferenceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellReferenceException"/> class.
        /// Initializes the exception for invalid cell reference.
        /// </summary>
        public InvalidCellReferenceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellReferenceException"/> class.
        /// Initializes the exception with the message.
        /// </summary>
        /// <param name="message"> The exception message.</param>
        public InvalidCellReferenceException(string message)
        : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellReferenceException"/> class.
        /// Initialize the exception with the message and inner exception.
        /// </summary>
        /// <param name="message"> The exception message.</param>
        /// <param name="inner"> The Inner exception.</param>
        public InvalidCellReferenceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
