// <copyright file="ColorCommand.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This colorCommand will allow to store the color change information
    /// Referenced the following youtube video to understand how command should work for redo and undo actions:
    /// https://www.youtube.com/watch?v=wDarY8fRGFI&t=3s.
    /// </summary>
    internal class ColorCommand : IUndoRedoCommand
    {
        /// <summary>
        /// Stores the current selected cells of the change that happened as a list.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected List<Cell> currentCells;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Stores the previous colors of each cell as a list.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected List<uint> previousBGColor;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Stores the new color of each cell.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        protected uint nextBGColor;
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorCommand"/> class.
        /// This will initialize the color commands as the input.
        /// </summary>
        /// <param name="newCell"> This stores all the cells that the user selected in a list.</param>
        /// <param name="newPreviousBGColor"> This stores all the cell's previous color that the cell had.</param>
        /// <param name="newNextBGColor"> This stores the new color of the cells.</param>
        public ColorCommand(List<Cell> newCell, List<uint> newPreviousBGColor, uint newNextBGColor)
        {
            this.currentCells = newCell;
            this.previousBGColor = newPreviousBGColor;
            this.nextBGColor = newNextBGColor;
        }

        /// <summary>
        /// Execute the redo action by setting each of the cell as the new color.
        /// </summary>
        public void ExecuteRedo()
        {
            foreach (Cell currentCell in this.currentCells)
            {
                currentCell.BGColor = this.nextBGColor;
            }
        }

        /// <summary>
        /// Execute the undo action by setting each of the cell as the previous color.
        /// </summary>
        public void ExecuteUndo()
        {
            int index = 0;
            foreach (Cell currentCell in this.currentCells)
            {
                currentCell.BGColor = this.previousBGColor[index];
                index++;
            }
        }

        /// <summary>
        /// Gets the type of the command.
        /// </summary>
        /// <returns> The string color.</returns>
        public new string GetType()
        {
            return "Color";
        }
    }
}
