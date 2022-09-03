using System;

namespace _10_1_9_Money
{
    public class Money
    {
        private readonly string _rubles = "р.";
        private readonly string _kopecks = "коп.";
        private int _numberOfRubles;
        private int _numberOfKopecks;

        public int NumberOfRubles
        {
            get { return _numberOfRubles; }
            set { _numberOfRubles = value; }
        }
        public int NumberOfKopecks
        {
            get { return _numberOfKopecks; }
            set
            {
                if (value > 99)
                {
                    NumberOfRubles += value / 100; //сломает класс. Потому что обязывает устанавливать значение NumberOfRubles до NumberOfKopecks. Так делать нельзя
                    _numberOfKopecks = value % 100;
                }
                else
                {
                    _numberOfKopecks = value;
                }
            }
        }

        public Money() { }

        public Money(string amount, string meaning)
        {
            var number = Convert.ToInt32(amount);

            if (number < 0)
                PrintMustNotBeNegative();
            else if (meaning == _rubles)
                NumberOfRubles = number;
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
                NumberOfRubles = tempNumberOfRubles;
                NumberOfKopecks = tempNumberOfKopecks;
            }
        }

        public static Money Sum(Money a, Money b)
        {
            var newMoney = new Money
            {
                NumberOfRubles = a.NumberOfRubles + b.NumberOfRubles,
                NumberOfKopecks = a.NumberOfKopecks + b.NumberOfKopecks
            };
            return newMoney;
        }

        public static Money Difference(Money a, Money b)
        {
            var newMoney = new Money
            {
                NumberOfRubles = a.NumberOfRubles - b.NumberOfRubles,
                NumberOfKopecks = a.NumberOfKopecks - b.NumberOfKopecks
            };
            if (newMoney.NumberOfRubles > 0 && newMoney.NumberOfKopecks < 0)
            {
                newMoney.NumberOfRubles -= 1;
                newMoney.NumberOfKopecks += 100;
            }
            return newMoney;
        }

        public void Print()
        {
            if (NumberOfRubles == 0 && NumberOfKopecks != 0)
                Console.WriteLine($"{NumberOfKopecks} {_kopecks}");
            else
                Console.WriteLine($"{NumberOfRubles} {_rubles} {NumberOfKopecks} {_kopecks}");
        }

        public void PrintTransferCost(double x)
        {
            double totalAmountOfKopecks = NumberOfRubles * 100 + NumberOfKopecks;
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
