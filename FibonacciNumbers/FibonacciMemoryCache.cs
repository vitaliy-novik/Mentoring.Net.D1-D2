using System;
using System.Runtime.Caching;

namespace FibonacciNumbers
{
	public class FibonacciMemoryCache : IFibonacciCache
	{
		private readonly ObjectCache cache = MemoryCache.Default;
		private const string Region = "Cache_Fibonacci";

		public int Get(int index)
		{
			return (int)cache.Get(index.ToString(), Region);
		}

		public void Set(int index, int value)
		{
			cache.Set(index.ToString(), value, ObjectCache.InfiniteAbsoluteExpiration, Region);
		}

		public bool IsCached(int index)
		{
			return cache.Contains(index.ToString(), Region);
		}
	}
}
