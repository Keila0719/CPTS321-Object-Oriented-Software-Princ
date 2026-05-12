// <copyright file="IUndoRedoCommand.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This is the interface of what each of the cell that is referencing this command will have.
    /// Referenced the following youtube video to understand how command should work for redo and undo actions:
    /// https://www.youtube.com/watch?v=wDarY8fRGFI&t=3s.
    /// </summary>
    public interface IUndoRedoCommand
    {
        /// <summary>
        /// This will execute the redo action to change the cells to the future.
        /// </summary>
        void ExecuteRedo();

        /// <summary>
        /// THis will execute the undo action to change the cells to the previous.
        /// </summary>
        void ExecuteUndo();

        /// <summary>
        /// This will return the type of the redo or undo.
        /// </summary>
        /// <returns> The string of the type of the current command.</returns>
        string GetType();
    }
}
