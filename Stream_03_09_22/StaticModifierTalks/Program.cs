using System;

namespace StaticModifierTalks
{
	class Program
	{
		static void Main(string[] args)
		{
			var a = new Foo();
			var b = new Foo();

			Console.WriteLine();
		}

		
	}

	class Foo
	{
		public int A { get; set; }

		public Foo Sum(Foo a)
		{
			return this + a;
		}

		public void Add(Foo a)
		{
			A = A + a.A;
		}

		public static Foo operator +(Foo left, Foo right)
		{
			return new Foo { A = left.A + right.A };
		}
	}

	class Calc
	{
		public static Foo Sum(Foo a, Foo b) => a + b;
	}
}
