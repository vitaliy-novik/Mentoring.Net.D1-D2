using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
	public class FibonacciNumbers
	{
		private readonly IFibonacciCache cache;

		private int maxCachedIndex = -1;

		public const int ZeroElement = 0;
		public const int FirstElement = 1;

		public FibonacciNumbers() { }

		public FibonacciNumbers(IFibonacciCache fibonacciCache)
		{
			this.cache = fibonacciCache;
		}

		public int Get(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			if (index == 0)
			{
				return ZeroElement;
			}
			if (index == 1)
			{
				return FirstElement;
			}

			if (this.cache != null)
			{
				return EvaluateWithCache(index);
			}

			return Evaluate(index);
		}

		private int Evaluate(int index)
		{
			throw new NotImplementedException();
		}

		private int EvaluateWithCache(int index)
		{
			if (index <= this.maxCachedIndex)
			{
				return cache.Get(index);
			}

			int currValue = cache.Get(maxCachedIndex);
			int prevValue = cache.Get(maxCachedIndex - 1);
		}
	}
}
