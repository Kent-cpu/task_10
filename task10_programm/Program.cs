using System;

namespace task10_programm
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(2, false);
            matrix.arr = new double[,] { { 4, 3 }, { 1, 2 } };
            matrix.inverseMatrix().print();
            Console.WriteLine(matrix.getElement(0, 1));
        }
    }
}
