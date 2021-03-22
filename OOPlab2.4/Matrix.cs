using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPlab2._4
{
    public class Matrix
    {
        public readonly int[,] MatrixData;
        private readonly int rows;
        private readonly int colums;
        /// <summary>
        //Індексатор
        public int this[int _row, int _colums]
        {
            set { MatrixData[_row, _colums] = value; }
            get { return MatrixData[_row, _colums]; }
        }
            
        public int Rows => MatrixData.GetLength(0);
        public int Colums => MatrixData.GetLength(1);
        public Matrix(int rows, int colums)
        {
            MatrixData = new int[rows, colums];
        }
        public Matrix(Matrix pereviosMatrix)
        {
            rows = pereviosMatrix.rows;
            colums = pereviosMatrix.colums;
            MatrixData = pereviosMatrix.MatrixData;
        }

        /// Заповнення матриці з консолі
        public void InputMatrix()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Colums; j++)
                {
                    Console.WriteLine($"Введіть[{i}][{j}] елемент матриці: ");
                    MatrixData[i, j] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                }
        }
        /// Вивід матриці на екран

        public void DisplayMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    Console.Write($"{ MatrixData[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// Перегрузка операторів в матриці

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
            Check(mat1, mat2);

            Matrix newMatrix = new Matrix(mat1.Rows, mat1.Colums);

            for (int x = 0; x < mat1.Rows; x++)
                for (int y = 0; y < mat1.Colums; y++)
                    newMatrix.MatrixData[x, y]
                        = mat1.MatrixData[x, y] + mat2.MatrixData[x, y];
            return newMatrix;
        }
        public static Matrix operator -(Matrix mat1, Matrix mat2)
        {
            Check(mat1, mat2);

            Matrix newMatrix = new Matrix(mat1.Rows, mat1.Colums);

            for (int x = 0; x < mat1.Rows; x++)
                for (int y = 0; y < mat1.Colums; y++)
                    newMatrix.MatrixData[x, y]
                        = mat1.MatrixData[x, y] - mat2.MatrixData[x, y];
            return newMatrix;
        }
        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            if (!(mat1.Rows == mat2.Colums))
                throw new Exception("Матриці на множаться");
            Matrix newMatrix = new Matrix(mat1.Rows, mat2.Colums);

            for (int i = 0; i < mat1.Rows; ++i)
                for (int j = 0; j < mat2.Colums; ++j)
                    for (int k = 0; k < mat1.Colums; ++k)
                        newMatrix.MatrixData[i, j] = (mat1.MatrixData[i, k] * mat2.MatrixData[k, j]);
            return newMatrix;
        }
        public static bool operator ==(Matrix mat1, Matrix mat2)
        {
            Check(mat1, mat2);
            var result = new List<bool>();

            for (int x = 0; x < mat1.Rows; x++)
                for (int y = 0; y < mat1.Colums; y++)
                    result.Add(mat1.MatrixData[x, y] == mat2.MatrixData[x, y]);

            return result.All(x => x == true);
        }
        public static bool operator !=(Matrix mat1, Matrix mat2)
        {
            Check(mat1, mat2);
            var result = new List<bool>();

            for (int x = 0; x < mat1.Rows; x++)
                for (int y = 0; y < mat1.Colums; y++)
                    result.Add(mat1.MatrixData[x, y] == mat2.MatrixData[x, y]);

            return result.All(x => x == false);
        }
        public double NormaMatrix()
        {
            double result = 0;
            for(int i = 0; i<Rows; i++)
                for(int j = 0; j<Colums; j++ )
                {
                    result += (MatrixData[i, j]* MatrixData[i, j]);
                }
            return Math.Sqrt(result);
        }
        static public void Check(Matrix mat1, Matrix mat2)
        {
            if (!(mat1.Rows == mat2.Rows || mat1.Colums == mat2.Colums))
                throw new InvalidOperationException();
        }
    }
}