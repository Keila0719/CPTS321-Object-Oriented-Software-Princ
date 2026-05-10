using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
	/// <summary>
	/// Represents a Node structure which stores number, left and right child nodes.
	/// </summary>
	/// <remarks>
	/// THis class includes methods to create a new node, getters and setters for the number of the node, 
	/// currnt node's left and right child nodes.
	/// </remarks>
	internal class Node
    {
        // A variable to store the number in the node
        private int number;
        // To access the left and right child nodes
        private Node left;
        private Node right;

		/// <summary>
		/// Accepts a number and initializes the node with a number and set the left and right nodes as null
		/// </summary> 
		/// <param name="number">A number that will be stored in the node </param>
		/// <return> a new node that was intialized </return>
		public Node(int number)
        {
            this.number = number;
            left = null;
            right = null;
        }

		/// <summary>
		/// Getter that allows access to the number stored in node
		/// </summary> 
		/// <return> the int number that was stored in node</return>
		public int GetNumber()
        {
            return number;
        }

		/// <summary>
		/// Getter that allows access to the left node
		/// </summary> 
		/// <return> the left child node of the current node</return>
		public Node GetLeft()
        {
            return left;
        }

		/// <summary>
		/// Getter that allows access to the right node
		/// </summary> 
		/// <return> the right child node of the current node</return>
		public Node GetRight()
        {
            return right;
        }

		/// <summary>
		/// Setter to set the left node for the current node
		/// </summary> 
		/// <param name="left"> left child node that would be set </param>
		/// <return> void, nothing</return>
		public void SetLeft(Node left)
        {
            this.left = left;
        }

		/// <summary>
		/// Setter to set the right node for the current node
		/// </summary> 
		/// <param name="right"> right child node that would be set </param>
		/// <return> void, nothing</return>
		public void SetRight(Node right)
        {
            this.right = right;
        }
    }
}
