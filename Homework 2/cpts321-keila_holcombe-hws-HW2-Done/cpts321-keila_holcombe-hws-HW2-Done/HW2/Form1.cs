using System.Text;

namespace HW2
{
/*****************************************************************
* Programmer: Keila Holcombe
* Class: CptS 321, Spring 2026;
* Programming Assignment: HW2
* Date: Feburary 4, 2026
* 
* Description: This project is to generate a 100000 random integer list where each of the
*			   random numbers are in the range of [0, 20000]. We will have three different method
*			   to find the distinct numbers, hashset, O(1) storage, and sortlist methods. Each
*			   of the method will have three test cases to test these methods.
*****************************************************************/

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			RunDistinctIntegers();
		}
		private void RunDistinctIntegers() // this is your method
		{
			StringBuilder stringBuilder = new StringBuilder();
			DistinctNumbers distinctNumbers = new DistinctNumbers();
			// Get a list with random integer numbers
			List<int> randomNumbers = distinctNumbers.GetRandomNumbersList();

			// By using that list, find the amount of Distinct number by using HashSet
			int hashSetDistinctNumber = distinctNumbers.FindDistinctNumberHashSet(randomNumbers);
			// Print the result 
			stringBuilder.AppendLine("1. HashSet method: " + hashSetDistinctNumber + " unique number");
			// time complexity explanation
			stringBuilder.AppendLine("HashSet method, this would have a time complexity of O(n) for both best and worst time complexity. This is" +
									 " because when adding a value to a HashSet, each value is added" +
									 " in O(1) time complexity. Each value of number would have a bucket" +
									 " where it will be inserted to. When trying to add a value to the" +
									 " HashSet, it will be able to immediately go to that bucket and insert" +
									 " that value. Additionally, when trying to add a value that already" +
									 " exists in the HashSet, it will find the position in O(1) time" +
									 " complexity and since that space is already occupied, there will be a " +
									 " collision. After the collision, it will just go to the next value since HashSet doesn't accept duplicates so go to the next" +
									 " value and try to insert the next value. This is why each .Add() is a O(1) time complexity and by" +
									 " repeating that for n numbers, in total, it will have a time complexity" +
									 " of O(n).");
			stringBuilder.AppendLine("HashSet method, this will also have a space complexity of O(n). THis is because each" +
									 "bucket in the hash set will have a place for each values (unless there is a duplicate). " +
									 "That means that if there are 100 distinct numbers in the list, the HashSet will also " +
									 "store 100 values.");

			// By using that list, find the amount of Distinct number by using nested for loop
			int nestedForLoopDistinctNumber = distinctNumbers.FindDistinctNumberNestedForLoops(randomNumbers);
			stringBuilder.AppendLine("2. O(1) storage method: " + nestedForLoopDistinctNumber + " unique number");
			// time complexity explanation
			stringBuilder.AppendLine("O(1) storage method, would have a time complexity of O(n^2) for worst time complexity and O(n) for best time complexity. "+
									 "There are two for loops that loops through the" +
									 " lists. One for loop will loop through each elements, for each element, there would be another loop that will loop through the list until"+
									 " it reaches the end or it finds a duplicate. Therefore, if there are no duplicate, the worst case would be O(n^2) since it needs fully loop" +
									 " for each element but if the list is sorted and there are duplicates for each element, the second loop will immediately end and the best" +
									 " the best time complexity would be O(n)");
			stringBuilder.AppendLine("O(1) storage method, would have a space complexity of O(1) because we are only using the inputted list and not creating other things that we will store the data.");
			// By using that list, find the amount of Distinct number by sorting the list
			int sortListDistinctNumber = distinctNumbers.FindDistinctNumberSortList(randomNumbers);
			stringBuilder.AppendLine("3. SortList method: " + sortListDistinctNumber + " unique number");
			stringBuilder.AppendLine("SortList method, since we are ignoring the sorting portion, it would have a time complexity of O(n) since we are only looping though each of the element once.");
			stringBuilder.AppendLine("SortList method, would have a space complexity of O(1) because we are only using the inputted list and not creating other things that we will store the data.");

			// Printing the strings to the textBox
			textBox1.Text = stringBuilder.ToString();
		}
	}
}
