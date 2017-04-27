using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
	public class DecimalRangeAttribute : ValidationAttribute
	{
		private const string DefaultErrorMessage = "The field {0} must be between {1} and {2}.";

		public decimal Min { get; set; }

		public decimal Max { get; set; }

		public DecimalRangeAttribute(double min, double max)
		{
			this.Min = new decimal(min);
			this.Max = new decimal(max);
		}

		public DecimalRangeAttribute(int min, int max)
		{
			this.Min = new decimal(min);
			this.Max = new decimal(max);
		}

		public override bool IsValid(object value)
		{
			if (this.Min > this.Max)
			{
				throw new ArgumentException($"{nameof(this.Max)} should be equal or greater than {nameof(this.Min)}");
			}

			if (!(value is decimal))
			{
				throw new InvalidOperationException();
			}

			decimal decimalValue = (decimal)value;

			return decimalValue >= this.Min && decimalValue <= this.Max;
		}

		public override string FormatErrorMessage(string name)
		{
			if (string.IsNullOrEmpty(ErrorMessage))
			{
				return String.Format(CultureInfo.CurrentCulture, DefaultErrorMessage, name, this.Min, this.Max);
			}

			return String.Format(CultureInfo.CurrentCulture, ErrorMessage, name, this.Min, this.Max);
		}

	}
}
