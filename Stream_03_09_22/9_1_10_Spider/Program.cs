using System;

namespace _9_1_10_Spider
{
	class Program
	{
		static void Main(string[] args)
        {
            var s1 = Console.ReadLine().Split(' ');
            var s2 = Console.ReadLine().Split(' ');
            var fly = new Fly
            {
                coordinateX = double.Parse(s1[0]),
                coordinateY = double.Parse(s1[1]),
                coordinateZ = double.Parse(s1[2]),
            };
            var spider = new Spider
            {
                coordinateX = double.Parse(s2[0]),
                coordinateY = double.Parse(s2[1]),
                coordinateZ = double.Parse(s2[2]),
            };

            if (fly.coordinateZ == 0)
            {
                Console.WriteLine("Расстояние: {0:0.#####}", Calculations.GetDistance(fly, spider));
                Console.WriteLine("Путь: {0:0.#####}", Calculations.GetWay(fly, spider));
            }
            else
                Console.WriteLine("Муха должна быть на полу!");
        }
    }
	}

    public class Fly
    {
        public double coordinateX;
        public double coordinateY;
        public double coordinateZ;
    }

    public class Spider
    {
        public double coordinateX;
        public double coordinateY;
        public double coordinateZ;
    }
    
    public class Calculations
    {
        public static double GetDistance(Fly fly, Spider spider) =>
           Math.Sqrt(Math.Pow(spider.coordinateX - fly.coordinateX, 2) +
                Math.Pow(spider.coordinateY - fly.coordinateY, 2) +
                Math.Pow(spider.coordinateZ - fly.coordinateZ, 2));
        public static double GetWay(Fly fly, Spider spider) =>
           Math.Sqrt(Math.Pow(spider.coordinateX - fly.coordinateX, 2) +
                Math.Pow(spider.coordinateY - fly.coordinateY, 2)) + (spider.coordinateZ - fly.coordinateZ);
    }
}
