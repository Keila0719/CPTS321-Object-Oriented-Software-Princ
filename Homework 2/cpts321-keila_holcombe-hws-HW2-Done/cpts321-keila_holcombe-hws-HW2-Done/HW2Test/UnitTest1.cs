using System;
using System.Collections.Generic;
using System.Text;
using HW2;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace HW2Test
{
	/// <summary>
	/// This class contains the three test cases for each methods. THe three test cases are normal, boundary,
	/// and error cases. These test will test if the methods are working as intended.
	/// </summary>
    [TestFixture]
    public class Tests
    {
		DistinctNumbers distinctNumbers = new DistinctNumbers();
		[SetUp]
        public void Setup()
        {
		}

		// Tests for FindDistinctNumbersHashSet() methods
 
		/// <summary> 
		/// Normal Case: This is a test method to test FindDistinctNumbersHashSet() method.
		/// This normal case test will test using expected values that is in the range of {0, 20000}
		/// with duplicated numbers to test if it will give expected result
		/// </summary>
		[Test]
		public void TestFindDistinctNumberHashSet_WithDuplicate()
		{
			// Having normal values from the range of [0, 20,000]
			List<int> normalList = new List<int> { 1, 1, 3, 7, 6, 6, 5, 7, 7, 9 };
			// Calling the method and storing the number of distinct numbers returned
			int resultNormalList = distinctNumbers.FindDistinctNumberHashSet(normalList);
            // Asserting that the result is as expected
            Assert.That(resultNormalList, Is.EqualTo(6));
		}
		
		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumbersHashSet() method. 
		/// This boundary case method test will test using limits of the oundary of [0, 20000] such as
		/// 0 and 20,000. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberHashSet_LimitNumbers()
		{
			// Testing for the numbers at the boundary or the end
			List<int> boundaryEndList = new List<int> { 0, 20000, 0, 20000 };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEndList = distinctNumbers.FindDistinctNumberHashSet(boundaryEndList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEndList, Is.EqualTo(2));
		} 
		
		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumbersHashSet() method.  
		/// This is to test if the method will still work even with an empty list. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberHashSet_EmptyList()
		{
			// Testing for an empty list
			List<int> boundaryEmptyList = new List<int> { };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEmptyList = distinctNumbers.FindDistinctNumberHashSet(boundaryEmptyList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEmptyList, Is.EqualTo(0));
		} 
		
		/// <summary> 
		/// Error Case: This is a test method to test FindDistinctNumberHashSet() method. 
		/// This is to test the values that will cause an error or overflow.It will test with values that 
		/// are out of bound like negative numbers or numbers over 20,000. Since these values are out of 
		/// bound, the expected result should be 0 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberHashSet_OutBoundary()
		{
			// Negative values or something out of the boundary of {0, 20,000}
			List<int> errorList = new List<int> { -4, -203, 20003, 203213 };
			// Calling the method and storing the number of distinct numbers returned
			int resultError = distinctNumbers.FindDistinctNumberHashSet(errorList);
            // Asserting that the result is as expected
            Assert.That(resultError, Is.EqualTo(4));
		}


		// Tests for FindDistinctNumberNestedForLoops() method 

		/// <summary> 
		/// Normal Case: This is a test method to test FindDistinctNumberNestedForLoops() method.
		/// This normal case test will test using expected values that is in the range of [0, 20000]
		/// with duplicated numbers to test if it will give expected result
		/// </summary>
		[Test]
		public void TestFindDistinctNumberNestedForLoops_WithDuplicate()
		{
			// Having normal values from the range of [0, 20,000]
			List<int> normalList = new List<int> { 1, 1, 3, 7, 6, 6, 5, 7, 7, 9 };
			// Calling the method and storing the number of distinct numbers returned
			int resultNormalList = distinctNumbers.FindDistinctNumberNestedForLoops(normalList);
            // Asserting that the result is as expected
            Assert.That(resultNormalList, Is.EqualTo(6));
		}
 
		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumberNestedForLoops() method. 
		/// This boundary case method test will test using limits of the oundary of [0, 20000] such as
		/// 0 and 20,000. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberNestedForLoops_LimitNumbers()
		{
			// Testing for the numbers at the boundary or the end
			List<int> boundaryEndList = new List<int> { 0, 20000, 0, 20000 };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEndList = distinctNumbers.FindDistinctNumberNestedForLoops(boundaryEndList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEndList, Is.EqualTo(2));
		}
 
		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumberNestedForLoops() method.  
		/// This is to test if the method will still work even with an empty list. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberNestedForLoops_EmptyList()
		{
			// Testing for an empty list
			List<int> boundaryEmptyList = new List<int> { };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEmptyList = distinctNumbers.FindDistinctNumberNestedForLoops(boundaryEmptyList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEmptyList, Is.EqualTo(0));
		}

		/// <summary> 
		/// Error Case: This is a test method to test FindDistinctNumberNestedForLoops() method. 
		/// This is to test the values that will cause an error or overflow.It will test with values that 
		/// are out of bound like negative numbers or numbers over 20,000. Since these values are out of 
		/// bound, the expected result should be 0. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberNestedForLoops_OutBoundary()
		{
			// Negative values or something out of the boundary of [0, 20,000]
			List<int> errorList = new List<int> { -4, -203, 20003, 203213 };
			// Calling the method and storing the number of distinct numbers returned
			int resultError = distinctNumbers.FindDistinctNumberNestedForLoops(errorList);
            // Asserting that the result is as expected
            Assert.That(resultError, Is.EqualTo(4));
		}


		// Tests for FindDistinctNumbersSortList() methods
		 
		/// <summary> 
		/// Normal Case: This is a test method to test FindDistinctNumbersSortList() method.
		/// This normal case test will test using expected values that is in the range of [0, 20000]
		/// with duplicated numbers to test if it will give expected result.
		/// </summary>
		[Test]
		public void TestFindDistinctNumberSortList_WithDuplicate()
		{
			// Having normal values from the range of [0, 20,000]
			List<int> normalList = new List<int> { 1, 1, 3, 7, 6, 6, 5, 7, 7, 9 };
			// Calling the method and storing the number of distinct numbers returned
			int resultNormalList = distinctNumbers.FindDistinctNumberSortList(normalList);
            // Asserting that the result is as expected
            Assert.That(resultNormalList, Is.EqualTo(6));
		}

		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumbersSortList() method. 
		/// This boundary case method test will test using limits of the oundary of [0, 20000] such as
		/// 0 and 20,000. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberSortList_LimitNumbers()
		{
			// Testing for the numbers at the boundary or the end
			List<int> boundaryEndList = new List<int> { 0, 20000, 0, 20000 };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEndList = distinctNumbers.FindDistinctNumberSortList(boundaryEndList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEndList, Is.EqualTo(2));
		}
 
		/// <summary> 
		/// Boundary Case: This is a test method to test FindDistinctNumbersSortList() method.  
		/// This is to test if the method will still work even with an empty list. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberSortList_EmptyList()
		{
			// Testing for an empty list
			List<int> boundaryEmptyList = new List<int> { };
			// Calling the method and storing the number of distinct numbers returned
			int resultBoundaryEmptyList = distinctNumbers.FindDistinctNumberSortList(boundaryEmptyList);
            // Asserting that the result is as expected
            Assert.That(resultBoundaryEmptyList, Is.EqualTo(0));
		}

		/// <summary> 
		/// Error Case: This is a test method to test FindDistinctNumbersSortList() method. 
		/// This is to test the values that will cause an error or overflow.It will test with values that 
		/// are out of bound like negative numbers or numbers over 20,000. Since these values are out of 
		/// bound, the expected result should be 0. 
		/// </summary>
		[Test]
		public void TestFindDistinctNumberSortList_OutBoundary()
		{
			// Negative values or something out of the boundary of [0, 20,000]
			List<int> errorList = new List<int> { -4, -203, 20003, 203213 };
			// Calling the method and storing the number of distinct numbers returned
			int resultError = distinctNumbers.FindDistinctNumberSortList(errorList);
            // Asserting that the result is as expected
            Assert.That(resultError, Is.EqualTo(4));
		}
	}
}
