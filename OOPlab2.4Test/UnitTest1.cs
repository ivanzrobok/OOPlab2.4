using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPlab2._4;
using System;

namespace OOPlab2._4Test
{
    [TestClass]
    public class UnitTest1
    {
        Matrix matrix1 = new Matrix(2, 2);
        Matrix matrix2 = new Matrix(2, 2);

        public void Initialisation()
        {
            matrix1.MatrixData[0, 0] = 1;
            matrix1.MatrixData[0, 1] = 2;
            matrix1.MatrixData[1, 0] = 3;
            matrix1.MatrixData[1, 1] = 4;

            matrix2.MatrixData[0, 0] = 1;
            matrix2.MatrixData[0, 1] = 2;
            matrix2.MatrixData[1, 0] = 3;
            matrix2.MatrixData[1, 1] = 4;

        }
        [TestMethod]
        public void TestMatrix1()
        {
            Assert.AreEqual(matrix1.Rows, 2);
            Assert.AreEqual(matrix1.Colums, 2);
            Assert.AreEqual(matrix2.Rows, 2);
            Assert.AreEqual(matrix2.Colums, 2);
        }
        [TestMethod]
        public void AddMatrix()
        {
            Initialisation();
            matrix2 += matrix1;
            Assert.AreEqual(2, matrix2[0, 0]);

        }
        [TestMethod]
        public void SubTractMatrix()
        {
            Initialisation();
            matrix2 -= matrix1;
            Assert.AreEqual(0, matrix2[1, 1]);
        }
        [TestMethod]
        public void Multiply()
        {
            Initialisation();
            matrix1 *= matrix2;
            Assert.AreEqual(matrix1[0, 1], 8);
        }
        [TestMethod]
        public void Normal()
        {
            Initialisation();
            Assert.AreEqual(matrix1.NormaMatrix(), Math.Sqrt(1 * 1 + 2 * 2 + 3 * 3 + 4 * 4));
            //sqrt(1*1+ 2*2 + 3*3 + 4* 4)
        }
    }
}
