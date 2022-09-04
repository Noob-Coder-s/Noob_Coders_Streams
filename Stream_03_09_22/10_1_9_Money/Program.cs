using System;

namespace _10_1_9_Money
{
    public class Money
    {
        private readonly string _rubles = "р.";
        private readonly string _kopecks = "коп.";

        public int NumberOfKopecks { get; set; }

        public Money() { }

        public Money(string amount, string meaning)
        {
            var number = Convert.ToInt32(amount);

            if (number < 0)
                PrintMustNotBeNegative();
            else if (meaning == _rubles)
                NumberOfKopecks = number * 100;
            else
                NumberOfKopecks = number;
        }

        public Money(string numberOfRubles, string rubles, string numberOfKopecks, string kopecks)
        {
            var tempNumberOfRubles = Convert.ToInt32(numberOfRubles);
            var tempNumberOfKopecks = Convert.ToInt32(numberOfKopecks);

            if (rubles != _rubles)
                PrintMixedUp();
            else if (tempNumberOfRubles < 0 || tempNumberOfKopecks < 0)
                PrintMustNotBeNegative();
            else
            {
                NumberOfKopecks = tempNumberOfRubles * 100 + tempNumberOfKopecks;
            }
        }

        public static Money Sum(Money a, Money b)
        {
            var newMoney = new Money
            {
                NumberOfKopecks = a.NumberOfKopecks + b.NumberOfKopecks
            };
            return newMoney;
        }

        public static Money Difference(Money a, Money b)
        {
            var newMoney = new Money
            {
                NumberOfKopecks = a.NumberOfKopecks - b.NumberOfKopecks
            };
            return newMoney;
        }

        public void Print()
        {
            var numberOfKopecks = NumberOfKopecks % 100;
            var numberOfRubles = NumberOfKopecks / 100;

            if (numberOfRubles == 0 && numberOfKopecks != 0)
                Console.WriteLine($"{numberOfKopecks} {_kopecks}");
            else
                Console.WriteLine($"{numberOfRubles} {_rubles} {numberOfKopecks} {_kopecks}");
        }

        public void PrintTransferCost(double x)
        {
            double totalAmountOfKopecks = NumberOfKopecks;
            totalAmountOfKopecks *= (x + 1);
            var ruble = (int)totalAmountOfKopecks / 100;
            var kopeck = (int)Math.Round(totalAmountOfKopecks % 100);

            if (totalAmountOfKopecks < 99) //тут меньше 100 должно быть по идее
                Console.WriteLine($"{kopeck} {_kopecks}");
            else
                Console.WriteLine($"{ruble} {_rubles} {kopeck} {_kopecks}");
        }

        private static void PrintMustNotBeNegative()
        {
            Console.WriteLine("Не может быть отрицательным!");
        }

        private static void PrintMixedUp()
        {
            Console.Write("Рубли и копейки перепутаны местами!");
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
