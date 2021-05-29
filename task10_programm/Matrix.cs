using System;


namespace task10_programm
{
    public class Matrix : ICloneable
    {
        public delegate Matrix matrixOperations(Matrix matrix);
        public double[,] arr = null;
        public bool isMatrix = true;
        public Matrix(byte SIZE, bool fillIn)
        {
            try
            {
                if (SIZE > 5)
                {
                    throw new MartixException();
                }
            }
            catch (MartixException ex)
            {
                Console.WriteLine(ex.message);

                return;
            }
            if (fillIn)
            {
                arr = new double[SIZE, SIZE];
                for (byte i = 0; i < SIZE; ++i)
                {
                    Random rnd = new Random();
                    for (byte j = 0; j < SIZE; ++j)
                    {
                        arr[i, j] = rnd.Next(1, 10);
                    }
                }
            }
            else
            {
                arr = new double[SIZE, SIZE];
            }
        }

        public string sumDiagonals()
        {
            double mainDiagonal = 0, sideDiagonal = 0;
            for (int i = 0; i < this.arr.GetLength(0); ++i)
            {
                mainDiagonal += this.arr[i, i];
                sideDiagonal += this.arr[i, this.arr.GetLength(0) - 1 - i];
            }
            Console.WriteLine($"Главная диагональ: {mainDiagonal}, побочная диагональ: {sideDiagonal}");
            return $"Главная диагональ: {mainDiagonal}, побочная диагональ: {sideDiagonal}";
        }

        public void print()
        {
            for (byte i = 0; i < arr.GetLength(0); ++i)
            {
                for (byte j = 0; j < arr.GetLength(0); ++j)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static Matrix operator +(Matrix MatrixL, Matrix MatrixR)
        {

            Matrix MatrixResult = new Matrix((byte)MatrixL.arr.GetLength(0), true);
            for (byte i = 0; i < MatrixL.arr.GetLength(0); ++i)
            {
                for (byte j = 0; j < MatrixL.arr.GetLength(0); ++j)
                {
                    MatrixResult.arr[i, j] = MatrixL.arr[i, j] + MatrixR.arr[i, j];
                }
            }
            return MatrixResult;
        }

        public static Matrix operator -(Matrix MatrixL, Matrix MatrixR)
        {
            Matrix MatrixResult = new Matrix((byte)MatrixL.arr.GetLength(0), true);
            for (byte i = 0; i < MatrixL.arr.GetLength(0); i++)
            {
                for (byte j = 0; j < MatrixL.arr.GetLength(0); j++)
                {
                    MatrixResult.arr[i, j] = MatrixL.arr[i, j] - MatrixR.arr[i, j];
                }
            }
            return MatrixResult;
        }

        public static Matrix operator *(Matrix MatrixL, Matrix MatrixR)
        {
            Matrix MatrixResult = new Matrix((byte)MatrixL.arr.GetLength(0), false);
            for (byte i = 0; i < MatrixL.arr.GetLength(0); ++i)
            {
                // цикл по каждому столбцу второй матрицы  
                for (byte j = 0; j < MatrixL.arr.GetLength(0); ++j)
                {
                    for (byte k = 0; k < MatrixL.arr.GetLength(0); ++k)
                    {
                        MatrixResult.arr[i, j] += MatrixL.arr[i, k] * MatrixR.arr[k, j];
                    }
                }
            }
            return MatrixResult;
        }

        public static bool operator >(Matrix MatrixL, Matrix MatrixR)
        {
            int difference = 0;
            for (byte i = 0; i < MatrixL.arr.GetLength(0); ++i)
            {
                for (byte j = 0; j < MatrixL.arr.GetLength(0); ++j)
                {
                    difference += MatrixL.arr[i, j] > MatrixR.arr[i, j] ? 1 : -1;
                }

            }
            return difference > 0;
        }

        public static bool operator ==(Matrix MatrixL, Matrix MatrixR)
        {
            return MatrixL > MatrixR && MatrixL < MatrixR;
        }


        public static bool operator <(Matrix MatrixL, Matrix MatrixR)
        {
            int difference = 0;
            for (byte i = 0; i < MatrixL.arr.GetLength(0); ++i)
            {
                for (byte j = 0; j < MatrixL.arr.GetLength(0); ++j)
                {
                    difference += MatrixL.arr[i, j] < MatrixR.arr[i, j] ? 1 : -1;
                }
            }
            return difference > 0;
        }

        public static bool operator >=(Matrix MatrixL, Matrix MatrixR)
        {
            return ((MatrixL == MatrixR) || (MatrixL > MatrixR));
        }

        public static bool operator <=(Matrix MatrixL, Matrix MatrixR)
        {
            return ((MatrixL == MatrixR) || (MatrixL < MatrixR));
        }



        public static bool operator true(Matrix matrix)
        {
            return matrix.arr != null;
        }

        public static bool operator false(Matrix matrix)
        {
            return matrix.arr == null;
        }


        public static bool operator !=(Matrix MatrixL, Matrix MatrixR)
        {
            return MatrixL == MatrixR ? false : true;
        }

        public double determinant()
        {
            return arr[0, 0] * arr[1, 1] - arr[0, 1] * arr[1, 0];
        }

        public double getElement(int iIndex, int jIndex)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(0); ++j)
                {
                    if (i != iIndex && j != jIndex)
                    {
                        return arr[i, j];
                    }
                }
            }
            return 0;
        }

        public Matrix inverseMatrix()
        {
            Matrix tempMatrix = new Matrix(2, true);
            double det = determinant();
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(0); ++j)
                {
                    tempMatrix.arr[i, j] = Math.Round(((i == 0 && j == 1) || (i == 1 && j == 0)) ? -1 * getElement(i, j) : getElement(i, j), 1);
                    tempMatrix.arr[i, j] = Math.Round((1 / det) * tempMatrix.arr[i, j], 1);
                }
            }
            return tempMatrix.transposing();
        }

        public Matrix transposing()
        {
            Matrix resultMatrix = this;
            double tmp = 0;
            for (int i = 0; i < resultMatrix.arr.GetLength(0); ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    tmp = resultMatrix.arr[i, j];
                    resultMatrix.arr[i, j] = resultMatrix.arr[j, i];
                    resultMatrix.arr[j, i] = tmp;
                }
            }
            return resultMatrix;
        }

        public static int CompareTo(Matrix MatrixL, Matrix MatrixR)
        {
            if (MatrixL > MatrixR)
            {
                return 1;
            }
            else if (MatrixL < MatrixR)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (byte i = 0; i < arr.GetLength(0); ++i)
            {
                for (byte j = 0; j < arr.GetLength(0); ++j)
                {
                    result += arr[i, j] + ",\t";
                }
                result += "\n";
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (isMatrix == ((Matrix)obj).isMatrix)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            Random rnd = new Random();
            return (int)arr[0, 0] + rnd.Next(0, 1000000);
        }

        public object Clone()
        {
            return this;
        }
    }
}



public class MartixException : Exception
{
    public string message = "Матрица слишком большой размерности";
    public int errorCode = 123;
    public MartixException()
    {
    }

    public MartixException(string message)
        : base(message)
    {
    }

    public MartixException(string message, Exception inner) : base(message, inner)
    {

    }
}