using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciNumbers.Tests
{
	[TestClass]
	public class FibonacciNumbersTest
	{
		int[] expectedValues = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

		[TestMethod]
		public void FibonacciNumbersWithoutCache()
		{
			FibonacciNumbers fibonacci = new FibonacciNumbers();
			for (int i = 0; i < expectedValues.Length; i++)
			{
				Assert.AreEqual(expectedValues[i], fibonacci.Get(i));
			}
		}

		[TestMethod]
		public void FibonacciNumbersMemoryCache()
		{
			FibonacciNumbers fibonacci = new FibonacciNumbers(new FibonacciMemoryCache());
			for (int i = 0; i < expectedValues.Length; i++)
			{
				Assert.AreEqual(expectedValues[i], fibonacci.Get(i));
			}
		}

		[TestMethod]
		public void FibonacciNumbersRedisCache()
		{
			FibonacciNumbers fibonacci = new FibonacciNumbers(new FibonacciRedisCache("localhost"));
			for (int i = 0; i < expectedValues.Length; i++)
			{
				Assert.AreEqual(expectedValues[i], fibonacci.Get(i));
			}
		}

		[TestMethod]
		public void FibonacciNumbersRedisCacheBig()
		{
			FibonacciNumbers fibonacci = new FibonacciNumbers(new FibonacciRedisCache("localhost"));
			var a = fibonacci.Get(100000);
		}
	}
}
