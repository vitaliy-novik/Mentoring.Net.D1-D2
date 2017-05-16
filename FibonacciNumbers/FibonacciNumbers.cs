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

		public const int ZeroElement = 0;
		public const int FirstElement = 1;

		public FibonacciNumbers() { }

		public FibonacciNumbers(IFibonacciCache fibonacciCache)
		{
			if (fibonacciCache == null)
			{
				throw new ArgumentNullException(nameof(fibonacciCache));
			}

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
				return this.EvaluateWithCache(index);
			}
			return this.Evaluate(index);
		}

		private int Evaluate(int index)
		{
			int currentIndex = 1;
			int currentValue = FirstElement;
			int previousValue = ZeroElement;

			while (currentIndex++ < index)
			{
				this.NextValues(ref previousValue, ref currentValue);
			}

			return currentValue;
		}

		private int EvaluateWithCache(int index)
		{
			int lastIndex = cache.GetLastIndex();
			if (index <= lastIndex)
			{
				return cache.Get(index);
			}

			int currentValue;
			int previousValue;
			if (lastIndex == 0)
			{
				lastIndex = 1;
				currentValue = FirstElement;
				previousValue = ZeroElement;
			}
			else
			{
				currentValue = cache.Get(lastIndex);
				previousValue = lastIndex == 2 ? FirstElement : cache.Get(lastIndex - 1);
			}

			while (++lastIndex <= index)
			{
				this.NextValues(ref previousValue, ref currentValue);
				cache.Set(lastIndex, currentValue);
			}

			return currentValue;
		}

		private void NextValues(ref int first, ref int second)
		{
			second += first;
			first = second - first;
		}
	}
}