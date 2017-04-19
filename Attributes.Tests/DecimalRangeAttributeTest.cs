using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Attributes.Tests
{
	[TestClass]
	public class DecimalRangeAttributeTest
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsValid_NullObject_ThrowsException()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(0m, 1m);

			attribute.IsValid(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsValid_NotDecimal_ThrowsException()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(0m, 2m);

			attribute.IsValid(2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IsValid_MaxLessThanMin_ThrowsException()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2.1m, 2m);

			attribute.IsValid(2);
		}

		[TestMethod]
		public void IsValid_ValueOutOfRange_ReturnsFalse()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2m, 2m);

			attribute.IsValid(2.002m);
		}

		[TestMethod]
		public void IsValid_ValueInRange_ReturnsTrue()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2m, 2.1m);

			attribute.IsValid(2.15m);
		}

		[TestMethod]
		public void IsValid_ValueOnBorder_ReturnsTrue()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(decimal.MinValue, decimal.MaxValue);

			attribute.IsValid(decimal.MaxValue);
		}
	}
}
