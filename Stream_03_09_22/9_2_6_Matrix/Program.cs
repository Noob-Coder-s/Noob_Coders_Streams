using System;
using System.Linq;

namespace _9_2_6_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read из класса убрать,
            //конструктор реиспользовать в методах,
            //перегрузка операторов
            //умножение матриц очень сложно сделано
            //неинформативные названия переменных

            var A = new Matrix();
            A.Read();

            var B = new Matrix();
            B.Read();

            A.Multiply(5).Sum(B.Multiply(2)).MultiplicationMartix(A).Write();
        }
    }

    public class Matrix
    {
        public int n;
        public int m;
        public double[][] data;

        public double[][] Read()
        {
            var line = Console.ReadLine().Split(' ');
            n = int.Parse(line[0]);
            m = int.Parse(line[1]);

            data = new double[n][];
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
            var result = new Matrix();
            result.data = new double[n][];
            result.n = n;
            result.m = m;

            for (int i = 0; i < n; i++)
                result.data[i] = new double[data[i].Length];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    result.data[i][j] = data[i][j] * multiplier;
            }

            return result;
        }

        public Matrix Sum(Matrix addendumTwo)
        {
            var result = new Matrix();
            result.data = new double[n][];
            result.n = n;
            result.m = m;

            for (int i = 0; i < n; i++)
                result.data[i] = new double[data[i].Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                    result.data[i][j] = addendumTwo.data[i][j] + data[i][j];
            }
            return result;
        }

        public Matrix MultiplicationMartix(Matrix multiplierTwo)
        {
            var result = new double[m];
            var indexN = 0;
            var indexM = 0;

            var newMatrix = new Matrix();
            newMatrix.data = new double[n][];

            for (int i = 0; i < n; i++)
                newMatrix.data[i] = new double[n];

            for (int dataN = 0, x = 0; dataN < data.Length; x++)
            {
                for (int dataM = 0; dataM < data[dataN].Length; dataM++)
                    result[dataM] += data[dataN][dataM] * multiplierTwo.data[dataM][x];

                if (indexN < data.Length && indexM < data.Length)
                {
                    newMatrix.data[indexN][indexM] += result.Sum();
                    indexM++;
                }
                if (indexM >= data.Length)
                {
                    indexM = 0;
                    indexN++;
                    dataN++;
                    x = -1;
                }
                Array.Clear(result, 0, result.Length);
            }
            return newMatrix;
        }
    }
}
