using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Example
{
	public enum TransportType
	{
		Train = 1,
		Airplane = 2
	}

	public class Client
	{
		public int Age { get; set; }
		public bool Pensionary { get; set; }

		public Client(int age, bool pensionary)
		{
			Age = age;
			Pensionary = pensionary;
		}
	}

	public class Route
	{
		public int Length { get; set; }
		public bool International { get; set; }
		public TransportType[] AvailableTransportTypes { get; set; }

		public Route(int length, bool international, params TransportType[] availableTransportTypes)
		{
			Length = length;
			International = international;
			AvailableTransportTypes = availableTransportTypes;
		}
	}

	class Program
	{
		static Dictionary<int, Client> Clients = new Dictionary<int, Client>
		{
			[1] = new Client(42, false),
			[2] = new Client(65, true),
			[3] = new Client(12, false),
			[4] = new Client(3, false),
		};

		static Dictionary<int, Route> Routes = new Dictionary<int, Route>
		{
			[1] = new Route(5_000, true, TransportType.Airplane, TransportType.Train),
			[2] = new Route(1_000, false, TransportType.Train),
			[3] = new Route(10_000, false, TransportType.Airplane)
		};

		static void Main(string[] args)
		{
			var clientId = int.Parse(Console.ReadLine());
			var transportType = (TransportType)int.Parse(Console.ReadLine());
			var routeId = int.Parse(Console.ReadLine());

			if (!Clients.TryGetValue(clientId, out var client))
				throw new KeyNotFoundException("There is no such client");

			if (!Routes.TryGetValue(routeId, out var route))
				throw new KeyNotFoundException("There is no such client");

			if (!route.AvailableTransportTypes.Contains(transportType))
				throw new ArgumentException("The selected route does not support the specified transport type");

			decimal costPerKilometer;

			if (transportType == TransportType.Airplane)
			{
				if (route.International)
					costPerKilometer = 200M;
				else
					costPerKilometer = 150M;
			}
			else
			{
				if (route.International)
					costPerKilometer = 100M;
				else
					costPerKilometer = 50M;
			}

			var tiketCost = route.Length * costPerKilometer;

			if (client.Age <= 3)
				tiketCost *= 0M;
			else if (client.Age <= 14)
				tiketCost *= 0.5M;

			if (client.Pensionary)
				tiketCost *= 0.75M;

			Console.WriteLine($"The ticket will cost {tiketCost} rubles");
		}
	}
}
