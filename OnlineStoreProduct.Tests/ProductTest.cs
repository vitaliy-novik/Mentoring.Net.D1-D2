using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnlineStoreProduct.Tests
{
	[TestClass]
	public class ProductTest
	{
		[TestMethod]
		public void Equals_NullObject_ReturnsFalse()
		{
			Product product = new Product();

			bool result = product.Equals(null);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_NotProduct_ReturnsFalse()
		{
			Product product = new Product("product", 1m, 1);
			var obj = new
			{
				Name = "product",
				Price = 1m,
				Amount = 1
			};

			bool result = product.Equals(obj);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Equals_SameInstances_ReturnsTrue()
		{
			Product product = new Product();

			bool result = product.Equals(product);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Equals_SymmetricCalls_ReturnsFalse()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productB", 124m, 12);

			bool straight = productA.Equals(productB);
			bool reverse = productB.Equals(productA);

			Assert.IsFalse(straight);
			Assert.IsFalse(reverse);
		}

		[TestMethod]
		public void Equals_SymmetricCalls_ReturnsTrue()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productA", 123m, 12);

			bool straight = productA.Equals(productB);
			bool reverse = productB.Equals(productA);

			Assert.IsTrue(straight);
			Assert.IsTrue(reverse);
		}

		[TestMethod]
		public void Equals_TransitiveCalls_ReturnsFalse()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productA", 123.1m, 12);
			Product productC = new Product("productC", 123m, 13);

			bool result = productA.Equals(productB) && productB.Equals(productC);
			bool transitive = productA.Equals(productC);

			Assert.IsFalse(result);
			Assert.IsFalse(transitive);
		}

		[TestMethod]
		public void Equals_TransitiveCalls_ReturnsTrue()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productA", 123m, 12);
			Product productC = new Product("productA", 123m, 12);

			bool result = productA.Equals(productB) && productB.Equals(productC);
			bool transitive = productA.Equals(productC);

			Assert.IsTrue(result);
			Assert.IsTrue(transitive);
		}

		[TestMethod]
		public void EqualsReturnsTrue_HashCodesEquals()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productA", 123m, 12);

			if (productA.Equals(productB))
			{
				Assert.IsTrue(productA.GetHashCode() == productB.GetHashCode());
			}
		}

		[TestMethod]
		public void HashCodesDifferent_EqualsReturnsFalse()
		{
			Product productA = new Product("productA", 123m, 12);
			Product productB = new Product("productA", 123.1m, 12);

			if (productA.GetHashCode() != productB.GetHashCode())
			{
				Assert.IsFalse(productA.Equals(productB));
			}
		}
	}
}
