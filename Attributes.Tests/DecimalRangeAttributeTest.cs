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
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(0, 1);

			attribute.IsValid(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsValid_NotDecimal_ThrowsException()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(0, 2);

			attribute.IsValid(2);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsValid_MaxLessThanMin_ThrowsException()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2.1, 2);

			attribute.IsValid(2);
		}

		[TestMethod]
		public void IsValid_ValueOutOfRange_ReturnsFalse()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2, 2);

			attribute.IsValid(2.002m);
		}

		[TestMethod]
		public void IsValid_ValueInRange_ReturnsTrue()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(2, 2.1);

			attribute.IsValid(2.15m);
		}

		[TestMethod]
		[ExpectedException(typeof(OverflowException))]
		public void IsValid_ValueOnBorder_ReturnsTrue()
		{
			DecimalRangeAttribute attribute = new DecimalRangeAttribute(double.MinValue, double.MaxValue);

			attribute.IsValid(decimal.MaxValue);
		}
	}
}
