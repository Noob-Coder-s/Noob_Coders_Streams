namespace OOP_Example
{
	public interface ICalculator
	{
		public decimal GetTotalTicketCost();
	}

	public interface IBaseCostProvider
	{
		public decimal GetBaseCost();
	}

	public interface IDiscountProvider
	{
		public decimal GetDiscount();
	}

	public class TicketCostCalculator : ICalculator
	{
		private IBaseCostProvider baseCostProvider;
		private IDiscountProvider discountProvider;

		public TicketCostCalculator(IBaseCostProvider baseCostProvider, IDiscountProvider discountProvider)
		{
			this.baseCostProvider = baseCostProvider;
			this.discountProvider = discountProvider;
		}

		public decimal GetTotalTicketCost()
		{
			return baseCostProvider.GetBaseCost() * discountProvider.GetDiscount();
		}
	}

	public class AirplaneBaseCostProvider : IBaseCostProvider
	{
		private Route route;

		public AirplaneBaseCostProvider(Route route)
		{
			this.route = route;
		}

		public decimal GetBaseCost()
		{
			if (route.International)
				return 200M;

			return 150M;
		}
	}

	public class TrainBaseCostProvider : IBaseCostProvider
	{
		private Route route;

		public TrainBaseCostProvider(Route route)
		{
			this.route = route;
		}

		public decimal GetBaseCost()
		{
			if (route.International)
				return 100M;

			return 50M;
		}
	}

	public class AgeDiscountProvider : IDiscountProvider
	{
		private Client client;

		public AgeDiscountProvider(Client client)
		{
			this.client = client;
		}

		public decimal GetDiscount()
		{
			if (client.Age <= 3)
				return 0M;
			else if (client.Age <= 14)
				return 0.5M;

			return 1M;
		}
	}


	public class SocialStatusDiscountProvider : IDiscountProvider
	{
		private Client client;

		public SocialStatusDiscountProvider(Client client)
		{
			this.client = client;
		}

		public decimal GetDiscount()
		{
			if (client.Pensionary)
				return 0.75M;

			return 1M;
		}
	}

	public class ComplexDiscountProvider : IDiscountProvider
	{
		private IDiscountProvider[] discountProviders;

		public ComplexDiscountProvider(params IDiscountProvider[] discountProviders)
		{
			this.discountProviders = discountProviders;
		}

		public decimal GetDiscount()
		{
			var result = 1M;

			foreach (var discountProvider in discountProviders)
			{
				result *= discountProvider.GetDiscount();
			}

			return result;
		}
	}
}
