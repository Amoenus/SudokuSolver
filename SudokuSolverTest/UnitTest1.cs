using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;

namespace SudokuSolverTest
{
    [TestClass]
    public class UnitTest1
    {
        List<List<int>> testSudoku = new List<List<int>>()
        {
            new List<int> {2,3,8,7,6,9,4,1,5},
            new List<int> {4,7,1,3,2,5,8,6,9},
            new List<int> {9,5,6,4,8,1,2,3,7},
            new List<int> {6,4,5,2,1,8,9,7,3},
            new List<int> {7,9,3,5,4,6,1,2,8},
            new List<int> {8,1,0,9,7,3,5,4,6},
            new List<int> {1,6,9,8,3,4,7,5,2},
            new List<int> {5,2,4,6,9,7,3,8,1},
            new List<int> {5,2,4,6,9,7,3,8,1},
            new List<int> {3,8,7,1,5,2,6,9,4}
        };

        SudokuHelper helper = new SudokuHelper();

        [TestMethod]
        public void Test_IsPossible_True()
        {
            bool result = helper.IsPossible(testSudoku, 2, 5, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_IsPossible_False()
        {
            bool result = helper.IsPossible(testSudoku, 2, 5, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Test_IsPossible_Invalid_Grid_Exception()
        {
            var smallGrid = new List<List<int>>() 
            {
                new List<int> { 1,2,3 },
                new List<int> { 4,5,6 },
                new List<int> { 7,8,9 }
            };
            helper.IsPossible(smallGrid, 0, 1, 2);
        }

    }
}
