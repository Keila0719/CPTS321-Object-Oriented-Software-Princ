// <copyright file="TextCommand.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This textCommand will allow to store the text change information
    /// Referenced the following youtube video to understand how command should work for redo and undo actions:
    /// https://www.youtube.com/watch?v=wDarY8fRGFI&t=3s.
    /// </summary>
    internal class TextCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Stores the current cell of the change that's happening.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected Cell currentCell;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Stores the previous text of the current cell.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected string previousText;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Stores the new change text change of the current cell.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected string nextText;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Initializes a new instance of the <see cref="TextCommand"/> class.
        /// Initialize each of the information with the input.
        /// </summary>
        /// <param name="cell"> The current cell that is being changed.</param>
        /// <param name="newPreviousText"> The string of text that was stored previously in this cell.</param>
        /// <param name="newNextText"> The string of text that this cell is being changed to. </param>
        public TextCommand(Cell cell, string newNextText)
        {
            this.currentCell = cell;
            this.previousText = cell.PreviousText;
            this.nextText = newNextText;
        }

        /// <summary>
        /// Execute the redo action for the cell by setting the current cell as the next text.
        /// </summary>
        public void ExecuteRedo()
        {
            this.currentCell.Text = this.nextText;
        }

        /// <summary>
        /// Execute the undo action for the cell by setting the current cell text as the previous text.
        /// </summary>
        public void ExecuteUndo()
        {
            this.currentCell.Text = this.previousText;
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns> The string text.</returns>
        public new string GetType()
        {
            return "Text";
        }
    }
}
