using System;
using System.Linq;

namespace _9_2_6_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //умножение матриц очень сложно сделано
            //неинформативные названия переменных

            var A = new Matrix(ReadTwoDimensionalArray());

            var B = new Matrix(ReadTwoDimensionalArray());

            var result = (5 * A + 2 * B) * A;

            result.Write();

            A.Multiply(5).Sum(B.Multiply(2)).MultiplicationMartix(A).Write();
        }

        static double[][] ReadTwoDimensionalArray()
        {
            var line = Console.ReadLine().Split(' ');
            var n = int.Parse(line[0]);
            var m = int.Parse(line[1]);

            var data = new double[n][];
            for (int i = 0; i < n; i++)
                data[i] = new double[m];

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine().Split(' ');
                for (int x = 0; x < line.Length; x++)
                    data[i][x] = double.Parse(line[x]);
            }
            return data;
        }
    }

    public class Matrix
    {
        public int n;
        public int m;
        public double[][] data;

        public Matrix() { }
		public Matrix(double[][] data)
		{
            this.data = data;
            n = data.GetLength(0);
            m = data.GetLength(1);
        }

        public void Write()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    if (j != data[i].Length - 1)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public Matrix Multiply(double multiplier)
        {
            return this * multiplier;
        }

        public static Matrix operator *(Matrix matrix, double multiplier)
        {
            return multiplier * matrix;
        }

        public static Matrix operator *(double multiplier, Matrix matrix)
        {
            var n = matrix.n;
            var m = matrix.m;
            var data = matrix.data;

            for (int i = 0; i < n; i++)
                data[i] = new double[data[i].Length];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    data[i][j] = data[i][j] * multiplier;
            }

            return new Matrix(data);
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            var n = left.n;
            var data = left.data;

            for (int i = 0; i < n; i++)
                data[i] = new double[data[i].Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                    data[i][j] = right.data[i][j] + data[i][j];
            }
            return new Matrix(data);
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            return (-1 * left) + right;
        }

        public Matrix Sum(Matrix addendumTwo)
        {
            return this + addendumTwo;
        }


        public static Matrix operator *(Matrix left, Matrix right)
        {
            var n = left.n;
            var m = left.m;
            var data = left.data;

            double result = 0;
            var indexN = 0;
            var indexM = 0;

            var newMatrix = new Matrix();
            newMatrix.data = new double[n][];

            for (int i = 0; i < n; i++)
                newMatrix.data[i] = new double[n];

            for (int dataN = 0, x = 0; dataN < data.Length; x++)
            {
                for (int dataM = 0; dataM < data[dataN].Length; dataM++)
                    result += data[dataN][dataM] * right.data[dataM][x];

                if (indexN < data.Length && indexM < data.Length)
                {
                    newMatrix.data[indexN][indexM] += result;
                    indexM++;
                }
                if (indexM >= data.Length)
                {
                    indexM = 0;
                    indexN++;
                    dataN++;
                    x = -1;
                }
            }
            return newMatrix;
        }

        public Matrix MultiplicationMartix(Matrix multiplierTwo)
        {
            return this * multiplierTwo;
        }
    }
}
