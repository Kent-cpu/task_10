using Microsoft.VisualStudio.TestTools.UnitTesting;
using task10_programm;
using System;

namespace MatrixT.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeterminate()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 1, 1}, {1, 1 } };
            double expected = 0;
            Assert.AreEqual(expected, matrix.determinant());
        }

        [TestMethod]
        public void inverseMatrixTest()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 1, 2}, { 3, 4 } };
            Matrix exceptedMatrix = new Matrix(2, false);
            exceptedMatrix.arr = new double[,] { {-2, 1 }, {1.5, -0.5 } };
            CollectionAssert.AreEqual(exceptedMatrix.arr, matrix.inverseMatrix().arr);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 1, 1 }, { 1, 1 } };
            string expected = "1,\t1,\t\n1,\t1,\t\n";
            Assert.AreEqual(expected, matrix.ToString());
        }

        [TestMethod]
        public void CloneTest()
        {
            Matrix matrix = new Matrix(2, true);
            Assert.AreEqual(matrix, matrix.Clone());
        }

        [TestMethod]
        public void sumDiagonal()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 5, 2 }, { 7, 10 } };
            int mainDiagonal = 15, sideDiagonal = 9;
            string expected = $"Главная диагональ: {mainDiagonal}, побочная диагональ: {sideDiagonal}";
            Assert.AreEqual(expected, matrix.sumDiagonals());
        }

        [TestMethod]
        public void transposingTest()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 5, 2 }, { 7, 10 } };
            Matrix exceptedMatrix = new Matrix(2, false);
            exceptedMatrix.arr = new double[,] { { 5, 7 }, { 2, 10 } };
            CollectionAssert.AreEqual(exceptedMatrix.arr, matrix.transposing().arr);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Matrix matrix1 = new Matrix(2, true);
            Matrix matrix2 = new Matrix(2, true);
           
            Assert.AreEqual(matrix1.Equals(matrix2), matrix2.Equals(matrix1));
        }

        [TestMethod]
        public void CompareToTest()
        {
            Matrix matrix1 = new Matrix(2, false);
            matrix1.arr = new double[,] { { 134, 520 }, { 902, 102 } };
            Matrix matrix2 = new Matrix(2, false);
            matrix2.arr = new double[,] { { 5, 7 }, { 2, 10 } };
            
            Assert.AreEqual(1, Matrix.CompareTo(matrix1, matrix2));
        }

        [TestMethod]
        public void getElementTest()
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 4, 3 }, { 1, 2 } };
            Assert.AreEqual(matrix.getElement(0, 1), 1);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            Matrix matrix1 = new Matrix(2, true);
            Matrix matrix2 = new Matrix(2, true);
            Assert.AreNotEqual(matrix1.GetHashCode(), matrix2.GetHashCode());
        }
    }
}
