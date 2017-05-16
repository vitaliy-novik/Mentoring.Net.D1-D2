using System;
using System.Runtime.Caching;

namespace FibonacciNumbers
{
	public class FibonacciMemoryCache : IFibonacciCache
	{
		private readonly ObjectCache cache = MemoryCache.Default;
		private const string Prefix = "Fibonacci";
		private const string MaxValueKey = "LastIndex";

		public int Get(int index)
		{
			return (int)cache.Get(Prefix + index.ToString());
		}

		public void Set(int index, int value)
		{
			cache.Set(Prefix + index.ToString(), value, ObjectCache.InfiniteAbsoluteExpiration);
			cache.Set(Prefix + MaxValueKey, index, ObjectCache.InfiniteAbsoluteExpiration);
		}

		public int GetLastIndex()
		{
			object index = cache.Get(Prefix + MaxValueKey);
			return index is int ? (int)index : 0;
		}
	}
}