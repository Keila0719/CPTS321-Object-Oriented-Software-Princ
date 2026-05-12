// <copyright file="UndoRedoManager.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Invoker for the command classes and manages the operations that can be done on the redo and undo.
    /// </summary>
    internal class UndoRedoManager
    {
        /// <summary>
        /// Stack where it will store each previous changes.
        /// </summary>
        private Stack<IUndoRedoCommand> undoStack;

        /// <summary>
        /// Stach where it will store each future changes.
        /// </summary>
        private Stack<IUndoRedoCommand> redoStack;

        /// <summary>
        /// This is used to not add undo changes when user presses undo.
        /// </summary>
        private bool undoAdded;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoManager"/> class.
        /// Initializes the two stacks.
        /// </summary>
        public UndoRedoManager()
        {
            this.undoStack = new Stack<IUndoRedoCommand>();
            this.redoStack = new Stack<IUndoRedoCommand>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether get and set the undoAdded.
        /// </summary>
        public bool UndoAdded
        {
            get => this.undoAdded;

            set
            {
                this.undoAdded = value;
            }
        }

        /// <summary>
        /// Clear both the stacks.
        /// </summary>
        public void ClearStacks()
        {
            this.undoStack.Clear();
            this.redoStack.Clear();
        }

        /// <summary>
        /// It will look at the undostack and return the correct text for the undo button.
        /// </summary>
        /// <returns> The text that should go on the undo button. </returns>
        public string GetUndoText()
        {
            // Check if it's empty
            if (this.undoStack.Count == 0)
            {
                return "Undo: Nothing to undo";
            }

            // Construct the button text by getting the type of the command
            string redoText = this.undoStack.Peek().GetType();
            return "Undo " + redoText + " Change";
        }

        /// <summary>
        /// It will look at the undostack and return the correct text for the redo button.
        /// </summary>
        /// <returns> The text that should go on the redo button. </returns>
        public string GetRedoText()
        {
            // Check if it's empty
            if (this.redoStack.Count == 0)
            {
                return "Redo: Nothing to redo";
            }

            // Construct the button text by getting the type of the command
            string redoText = this.redoStack.Peek().GetType();
            return "Redo " + redoText + " Change";
        }

        /// <summary>
        /// Allows to add the current changes to the undo stack.
        /// </summary>
        /// <param name="data"> The changes that just happened.</param>
        public void AddUndo(IUndoRedoCommand data)
        {
            // Push the changes to the stack
            this.undoStack.Push(data);

            // Since when we have new changes, it will clear the redo stack
            this.redoStack.Clear();
        }

        /// <summary>
        /// Allows us to add the undo changes to the redo changes.
        /// </summary>
        /// <param name="data"> The changes from undo.</param>
        public void AddRedo(IUndoRedoCommand data)
        {
            // Push that changes to the stack
            this.redoStack.Push(data);
        }

        /// <summary>
        /// Execute the redo action and update each cell to the changes in the redo stack.
        /// </summary>
        public void ExecuteRedo()
        {
            // Check if the current redo stack is empty or not, if empty return
            if (this.redoStack.Count() == 0)
            {
                return;
            }

            // Get and remove the change information from the redostack
            IUndoRedoCommand current = this.redoStack.Pop();

            // To make sure this change doesn't get added as a new change, make undoAdded as true
            this.UndoAdded = true;

            // Execute the redo action depending on their command type
            current.ExecuteRedo();
            this.UndoAdded = false;

            // Push the current state before executing the redo to undo stack
            this.undoStack.Push(current);
        }

        /// <summary>
        /// Execute the undo action and update each cell to the changes in the undo stack.
        /// </summary>
        public void ExecuteUndo()
        {
            // Check if the current undo stack is empty or not, if empty return
            if (this.undoStack.Count() == 0)
            {
                return;
            }

            // Get and remove the changed information from the undostack
            IUndoRedoCommand current = this.undoStack.Pop();

            // Since we need to also come back to current instance, add the current situation to redostack
            this.AddRedo(current);

            // To make sure the changes happened here don't get added as a new change, make undoAdded as true
            this.UndoAdded = true;

            // Execute the undo action depending on their command type
            current.ExecuteUndo();
            this.UndoAdded = false;
        }
    }
}
