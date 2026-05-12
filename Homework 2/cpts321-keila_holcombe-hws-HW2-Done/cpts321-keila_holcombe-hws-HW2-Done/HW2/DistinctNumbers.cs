using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HW2
{
	/// <summary>
	/// This class is where the methods were implemented. a method that generates 100000 random 
	/// integer list where each of the random numbers are in the range of[0, 20000]. We will have 
	/// three different method to find the distinct numbers, hashset, O(1) storage, and sortlist methods.
	/// </summary>
	public class DistinctNumbers
	{
		
		 /// <summary> 
		 /// Generate a random 10000 number of integers from the range
		 /// of [0, 20000] and store it into a list and return. 
		 /// </summary>
		 /// <returns> 
		 /// List of 10000 integer numbers 
		 /// </returns>
		public List<int> GetRandomNumbersList()
		{
			Random rand = new Random();
			List<int> randomNumbers = new List<int>();
			// loop for 10000 times and add 10000 random integers into the list
			for (int i = 0; i < 10000; i++)
			{
				// Get a random number in the range of [0, 20000]
				int randomInteger = rand.Next(0, 20000);
				// Store that random integer into the list
				randomNumbers.Add(randomInteger);
			}
			return randomNumbers;
		}

		/// <summary> 
		/// Accepts a list int that contains random integer number and 
		/// count how many distinct numbers are in the list by using HashSet 
		/// </summary>
		/// <param name="randomNumbers"> List of random integer numbers </param>
		/// <returns> 
		/// Count the number of distinct numbers in the list 
		/// </returns>
		public int FindDistinctNumberHashSet(List<int> randomNumbers)
		{
			// Create a HashSet to store distinct numbers
			HashSet<int> distinctNumbers = new HashSet<int>();
			// Storing the random numbers from the randomNumber list into a HashSet
			int length = randomNumbers.Count;
			for (int i = 0; i < length; i++)
			{
				// Adding numbers to the HashSet
				distinctNumbers.Add(randomNumbers[i]);
			}

			// Count the amount of distinct numbers by getting the amount of values inside the hashset
			int distinctCount = distinctNumbers.Count;
			return distinctCount;
		}

		 /// <summary> 
		 /// Accept a list int that contains random numbers and will
		 /// count how many distinct numbers are in the list by using nested for loops. There will
		 /// be a if statement for checking duplicate and will only use O(1) memory. 
		 /// </summary>
		 /// <param name="randomNumbers"> List of random integer numbers </param>
		 /// <returns> 
		 /// Count the number of distinct numbers in the list 
		 /// </returns>
		public int FindDistinctNumberNestedForLoops(List<int> randomNumbers)
		{
			int distinctCount = 0;
			// Using nested for loop to check for duplicate
			for (int i = 0; i < randomNumbers.Count; i++)
			{
				// make the bool variable as false to indicate the duplicate hasn't been found yet
				bool duplicateFound = false;
				for (int j = i + 1; j < randomNumbers.Count; j++)
				{
					// Checking if there are any duplicated number in the later list
					if (randomNumbers[j] == randomNumbers[i])
					{
						//if yes, let duplicateFound as true and break
						duplicateFound = true;
						break;
					}
				}
				// After the second loop, if the duplicateFound was false, increase the distinctCount by one
				if (duplicateFound == false)
				{
					// Since there was no duplicate for the later list, increase distinct Count
					distinctCount++;
				}
			}
			return distinctCount;
		}

		 /// <summary> 
		 /// Accept a list int that contains random numbers and will
		 /// count how many distinct numbers are in the list by sorting the list. It will be sorted
		 /// with O(1) storage, no dynamic memory allocation, and O(n) time complexity 
		 /// </summary>
		 /// <param name="randomNumbers"> List of random integer numbers </param>
		 /// <returns> 
		 /// Count the number of distinct numbers in the list 
		 /// </returns>
		public int FindDistinctNumberSortList(List<int> randomNumbers)
		{
			// Sort the random numbers using the built-in sorting functionality
			randomNumbers.Sort();
			int distinctCount = 0;
			// Loop through the list to find when the current number and the next number is different
			for (int i = 0; i < randomNumbers.Count(); i++)
			{
				// Check if the next number exits or not
				if (i + 1 == randomNumbers.Count())
				{
					// increase the distinctCount since there are no more duplicate of their own
					distinctCount++;
				}
				// Check if the current number is different than the next number
				else if (randomNumbers[i] != randomNumbers[i + 1])
				{
					//When they are different, showing there are another distinct number
					distinctCount++;
				}
			}
			return distinctCount;
		}
	}
}
