using System;

namespace OnlineStoreProduct
{
	public struct Product
	{
		public string Name { get; }
		public decimal Price { get; }
		public int Amount { get; }
		
		public Product(string name, decimal price, int amount)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException(nameof(name));
			}

			if (price < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(price));
			}

			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount));
			}

			this.Name = name;
			this.Price = price;
			this.Amount = amount;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Product))
			{
				return false;
			}

			return this.Equals((Product) obj);
		}

		public bool Equals(Product product)
		{
			return (product.Name == this.Name) && (product.Price == this.Price) && (product.Amount == this.Amount);
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode() ^ this.Price.GetHashCode() ^ this.Amount.GetHashCode();
		}

		public static bool operator ==(Product productA, Product productB)
		{
			return productA.Equals(productB);
		}

		public static bool operator !=(Product productA, Product productB)
		{
			return !(productA == productB);
		}
	}
}
