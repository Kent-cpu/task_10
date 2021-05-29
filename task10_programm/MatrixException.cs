using System;


namespace task10_programm
{
    public class MatrixException : Exception
    {
        public string message = "Матрица слишком большой размерности";
        public int errorCode = 123;
        public MatrixException()
        {
        }

        public MatrixException(string message)
            : base(message)
        {
        }

        public MatrixException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
