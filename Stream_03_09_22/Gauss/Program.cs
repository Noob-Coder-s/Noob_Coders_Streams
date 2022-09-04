using System;

namespace Gauss
{
	class Program
	{
        static void Main(string[] args)
        {
            //x + 3y + 2z = 19
            //4x + y - 4z = 9
            //10x - 2y + z = 11

            var free = new double[3]
            {
                19,
                9,
                11
            };

            var matrix = new double[3, 3]
            {
                { 1, 3, 2 },
                { 4, 1, -4 },
                { 10, -2, 1 }
            };

            var result = Gauss(matrix,free);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"x{i} = {result[i]}");
            }
        }

        static double[] Gauss(double[,] matrix, double[] free)
        {       
            var size = matrix.GetLength(0);

            for (int i = 0; i < size - 1; i++)
            {       
                //приводим к треугольному виду
                for (int j = i + 1; j < size; j++)
                {
                    double сoef = matrix[j, i] / matrix[i, i];

                    for (int k = i; k < size; k++)
                    {
                        matrix[j, k] -= matrix[i, k] * сoef;
                    }

                    free[j] -= free[i] * сoef;
                }
            }

            double[] resultVector = new double[size];

            //обратный проход
			for (int i = size - 1; i >= 0; i--)
			{
                var freeElement = free[i];
				for (int j = size - 1; j > i; j--)
				{
                    freeElement -= resultVector[j] * matrix[i, j];
                }

                resultVector[i] = freeElement / matrix[i, i];
			}

            return resultVector;
        }
    }
}
