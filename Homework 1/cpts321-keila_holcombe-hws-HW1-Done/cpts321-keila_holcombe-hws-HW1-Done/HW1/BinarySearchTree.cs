using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace HW1
{

	/// <summary>
	/// Represents a Binary Search Tree data structure which stores nodes and organizes them based on their values.
	/// </summary>
	/// <remarks>
	/// THis class includes methods to create a Binary Search Tree, insert nodes, traverse the tree in 
	/// order, count the number of nodes, number of levels, and calculates the theoretical minimum 
	/// number of levels based on the number of nodes in the Binary Search Tree.
	/// </remarks>
	internal class BinarySearchTree
    {
        private Node root;

		/// <summary>
		/// Initializing a root node as null
		/// </summary> 
		/// <return> void, nothing </return>
		public BinarySearchTree() { 
			root = null;
		}

		/// <summary>
		/// Using the Split function to separate the numbers from the input string and store them in an
		/// array. Then it will store each number in the Binary Search Treee in order of the user input
		/// </summary> 
		/// <param name="input">A string of numbers seprated by spaces that the user inputted </param>
		/// <return> void, nothing </return>
		public void SeparateNumbers(string input)
        {
			//Check if the string is empty
			if (string.IsNullOrWhiteSpace(input))
			{
				return;
			}
			// Separating the numbers from the user input string by using the split function and storing
			// them into an array
			string[] inputNumbers = input.Split(' '); // This split function is amazing!

			int index = 0;
			// Inserting each number into the Binary Search Tree
			while (inputNumbers.Length != index)
			{
				// Converting each string numbers into int.
				int currentNumber = int.Parse(inputNumbers[index]);
				// Creating a new node with the current number
				Node newNode = new Node(currentNumber);
				// Inserting the new node into the Binary Search Tree by calling insertNode function
				InsertNode(newNode);
				index++;
			}
		}

		/// <summary>
		/// Inputs a node into the Binary Search Tree. It will look for the correct position to insert the node
		/// </summary> 
		/// <param name="node">A new node that will be inserted into the Binary Search Tree </param>
		/// <return> void, nothing </return>
		public void InsertNode(Node node)
        {
			// If the root is empty, insert the node at root
			if (root == null)
			{
				root = node;
			}
			// If the root is not empty, find the correct position to insert the node
			Node current = root;
			// Find the corresponding spot to insert the node
			while (current != null)
			{
				if (node.GetNumber() == current.GetNumber())
				{
					// Found a duplicate, don't insert
					return;
				}
				else if (node.GetNumber() < current.GetNumber()) // Compare the new node with the current node
				{
					// Check if current's left subtree is null
					if (current.GetLeft() == null)
					{
						// If it's null, found the spot to insert
						current.SetLeft(node);
						return;
					}
					else
					{
						// If it's not null, get left subtree
						current = current.GetLeft();
					}					
				}
				else
				{
					// Check if current's right subtree is null
					if (current.GetRight() == null)
					{
						// If it's null, found the spot to insert
						current.SetRight(node);
						return;
					}
					else
					{
						// If it's not null, get right subtree
						current = current.GetRight();
					}
				}
			}
		}

		/// <summary>
		/// It will recursively print the Binary Search Tree in order of smallest to largest values
		/// Reference: For this method, I used the following website to understand how to do in-order traversal:
		/// https://www.geeksforgeeks.org/dsa/binary-search-tree-traversal-inorder-preorder-post-order/
		/// </summary> 
		/// <param name="node">The root node of the Binary Search Tree </param>
		/// <return> void, nothing </return>
		public void PrintInOrderTraversal(Node node)
		{
			// If the current node is null, return
			if (node == null)
			{
				return;
			}

			// Traverse to the left subtree
			PrintInOrderTraversal(node.GetLeft());
			// Print the values in the node
			Console.Write(node.GetNumber() + " ");
			// Traverse to the right subtree
			PrintInOrderTraversal(node.GetRight());
		}

		/// <summary>
		/// Recursively count the amount of nodes in the Binary Search Tree
		/// </summary> 
		/// <param name="node">The root node of the Binary Search Tree </param>
		/// <return> int, the number of nodes in the tree </return>
		public int GetNumberOfNodes(Node node)
        {
			// If the current node is null, return 0
			if (node == null)
			{
				return 0;
			}
			else
			{
				// If the root is not null, recursively count the nodes in the tree
				return 1 + GetNumberOfNodes(node.GetLeft()) + GetNumberOfNodes(node.GetRight());
			}
		}

		/// <summary>
		/// Recursively count the number of levels in the Binary Search Tree
		/// Reference: I referenced the following website to understand how to find the number of levels in a tree:
		/// https://www.geeksforgeeks.org/dsa/find-the-maximum-depth-or-height-of-a-tree/
		/// </summary> 
		/// <param name="node">The root node of the Binary Search Tree </param>
		/// <return> int, the number of levels in the tree </return>
		public int GetNumberOfLevels(Node node)
        {
			// If current node is null, return -1
			if (node == null)
			{
				return 0;
			}

			// Recursively get the height of the left and right subtrees
			int leftHeight = 1 + GetNumberOfLevels(node.GetLeft());
			int rightHeight = 1 + GetNumberOfLevels(node.GetRight());

			// Check which subtree is taller and return the height
			if (leftHeight > rightHeight)
			{
				return leftHeight;
			}
			else
			{
				return rightHeight;
			}
		}

		/// <summary>
		/// Calculate the theoretical minimum number of levels that the tree could have based on 
		/// the number of nodes it contains
		/// </summary> 
		/// <param name="numberOfNodes">The total number of nodes in the tree </param>
		/// <return> int, theoretical minimum number of levels the tree has </return>
		public int GetMinimumLevelNodes(int numberOfNodes)
        {
			// I believe the Theoretical minimum number of levels that the tree could have given the number of nodes
			// it contains can be found when the tree is balanced.

			// I referenced the following websites to understand how to do log_2 and ceiling functions in C#:
			// https://www.geeksforgeeks.org/c-sharp/c-sharp-math-log-method/
			// https://www.geeksforgeeks.org/c-sharp/c-sharp-math-ceiling-method/
			int totalLevels = (int)Math.Ceiling(Math.Log(numberOfNodes + 1, 2));
			return totalLevels;
		}

		/// <summary>
		/// Getter that allows access to the root node of the Binary Search Tree
		/// </summary> 
		/// <return> int, the root node of the Binary Search Tree </return>
		public Node GetRoot()
		{
			return root;
		}
	}
}
