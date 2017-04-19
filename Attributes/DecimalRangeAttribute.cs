using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
	public class DecimalRangeAttribute : ValidationAttribute
	{
		public decimal Min { get; }
		public decimal Max { get; }

		public DecimalRangeAttribute(decimal min, decimal max)
		{
			if (min > max)
			{
				throw new ArgumentException($"{nameof(max)} should be equal or greater than {nameof(min)}");
			}

			this.Min = min;
			this.Max = max;
		}

		public override bool IsValid(object value)
		{
			if (!(value is decimal))
			{
				throw new InvalidOperationException();
			}

			decimal decimalValue = (decimal)value;

			return decimalValue >= this.Min && decimalValue <= this.Max;
		}

	}
}
