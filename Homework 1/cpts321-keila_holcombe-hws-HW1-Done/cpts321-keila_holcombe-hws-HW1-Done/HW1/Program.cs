/*****************************************************************
* Programmer: Keila Holcombe
* Class: CptS 321, Spring 2026;
* Programming Assignment: HW1
* Date: January 28, 2026
* 
* Description: In this program, it will ask the user to enter a line of numbers in a range [0,100] and
*			   seprate number with spaces. Then we will seprate each numbers and enter them into a Binary
*			   Search Tree. After inserting them in order, it will display numbers inorder, number of nodes,
*			   max level, and theoretical min levels.  
*			   
* Tests: Normal: I entered number from [0,100] with some duplicate number to make sure the code works as intended
*		 Boundary: Empty input/string, when entered an empty string, at first it gave me an error but I added an if statement
*				to not operate split function when the user enters an empty input which fixed my error.
*		 Overflow/Error: Since this assignments assumes the user will enter numbers from [0,100] with spaces in between the numbers,
*				I didn't there was any overflow or error case we can test.
*				
* References: I don't know C# much so I searched up some C# code to understand basic C# syntax, such as how to write the main method,
*			  how to print works, and some math operations such like for log_2 and rounding. The following are the links to the reference:
*			  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
*			  https://www.geeksforgeeks.org/c-sharp/c-sharp-math-log-method/
*			  https://www.geeksforgeeks.org/c-sharp/c-sharp-math-ceiling-method/
*			  To understand how to do a comment block and the proper style, I visited Microsoft website to learn it:
*			  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
*			  I also referen GeeksForGeeks to understand how to do some operations. The following are the links
*			  to the references:
*			  https://www.geeksforgeeks.org/dsa/find-the-maximum-depth-or-height-of-a-tree/
*			  https://www.geeksforgeeks.org/dsa/binary-search-tree-traversal-inorder-preorder-post-order/
*		I have also attached this thw following likes above the code I referenced.
*		
*****************************************************************/
using System;
using HW1;

/// <summary>
/// The Program class will handle user interactions by printing informations and accepting inputs
/// </summary>
/// <remarks>
/// It will asks the user for their number input, calls methods in BinarySearchTree.cs to get values 
/// like tree contents and statistics.
/// </remarks>
public class Program
{
	public static void Main(string[] arg)
	{
		// I learned how to print a line from the following website: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators
		// Ask the user to enter a number in the range [0,100] and seprate numbers with spaces
		Console.WriteLine("Enter a collection of numbers in the range [0,100] and seprate numbers with spaces: ");

		// Get the user input using Console.ReadLine
		string input = Console.ReadLine();

		// Save each numbers into a BST tree in the order they were entered by calling the seprateNumbers function
		BinarySearchTree binarySearchTree = new BinarySearchTree();
		binarySearchTree.SeparateNumbers(input);

		// Display the number in sorted order
		Console.WriteLine("\nTree contents: ");
		binarySearchTree.PrintInOrderTraversal(binarySearchTree.GetRoot());

		// Get and display the number of items in the tree
		Console.WriteLine("\n\nTree Statistics: ");
		int numberOfNodes = binarySearchTree.GetNumberOfNodes(binarySearchTree.GetRoot());
		Console.WriteLine("  Number of nodes: " + numberOfNodes);

		// Get and display the number of levels in the tree
		int numberOfLevels = binarySearchTree.GetNumberOfLevels(binarySearchTree.GetRoot());
		Console.WriteLine("  Number of levels: " + numberOfLevels);

		// Get and display the minimum number of level it can have with the current number of nodes
		int minimumNumberOfLevels = binarySearchTree.GetMinimumLevelNodes(numberOfNodes);
		Console.WriteLine("  Minimum number of levels that a tree with " + numberOfNodes + " nodes could have = " + minimumNumberOfLevels);
	}
}
