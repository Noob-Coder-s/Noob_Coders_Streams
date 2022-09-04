using System;

namespace _9_1_10_Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = Console.ReadLine().Split(' ');
            var s2 = Console.ReadLine().Split(' ');
            var fly = new Point
            {
                CoordinateX = double.Parse(s1[0]),
                CoordinateY = double.Parse(s1[1]),
                CoordinateZ = double.Parse(s1[2]),
            };
            var spider = new Point
            {
                CoordinateX = double.Parse(s2[0]),
                CoordinateY = double.Parse(s2[1]),
                CoordinateZ = double.Parse(s2[2]),
            };

            if (fly.CoordinateZ == 0)
            {
                Console.WriteLine("Расстояние: {0:0.#####}", Calculations.GetDistance(fly, spider));
                Console.WriteLine("Путь: {0:0.#####}", Calculations.GetWay(fly, spider));
            }
            else
                Console.WriteLine("Муха должна быть на полу!");
        }
    }

    public class Point
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
    }

    public class Calculations
    {
        public static double GetDistance(Point fly, Point spider) =>
           Math.Sqrt(Math.Pow(spider.CoordinateX - fly.CoordinateX, 2) +
                Math.Pow(spider.CoordinateY - fly.CoordinateY, 2) +
                Math.Pow(spider.CoordinateZ - fly.CoordinateZ, 2));
        public static double GetWay(Point fly, Point spider) =>
           Math.Sqrt(Math.Pow(spider.CoordinateX - fly.CoordinateX, 2) +
                Math.Pow(spider.CoordinateY - fly.CoordinateY, 2)) + (spider.CoordinateZ - fly.CoordinateZ);
    }

}