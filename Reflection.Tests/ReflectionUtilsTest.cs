using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Reflection.Tests
{
	[TestClass]
	public class ReflectionUtilsTest
	{
		[TestMethod]
		public void CreateList_Int()
		{
			var list = ReflectionUtils.CreateList<int>();

			Assert.AreEqual(typeof(List<int>), list.GetType());
			ReflectionUtils.AddListItem<int>(list, 4);
		}
	}
}
