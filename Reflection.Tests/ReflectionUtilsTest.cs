using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Reflection.Tests
{
	[TestClass]
	public class ReflectionUtilsTest
	{
		Type stringType = Type.GetType("System.String");
		Type intType = Type.GetType("System.Int32");

		[TestMethod]
		public void CreateList_Int()
		{
			var list = ReflectionUtils.CreateGenericList(this.intType);

			Assert.AreEqual(typeof(List<int>), list.GetType());
		}

		[TestMethod]
		public void CreateList_String()
		{
			var list = ReflectionUtils.CreateGenericList(this.stringType);

			Assert.AreEqual(typeof(List<string>), list.GetType());
		}

		[TestMethod]
		public void AddIWithReflection_Int()
		{
			var list = ReflectionUtils.CreateGenericList(this.intType);
			
			list.AddWithReflection(Activator.CreateInstance(this.intType));

			Assert.IsTrue(list.Contains(0));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddIWithReflection_Int_ThrowException()
		{
			var list = ReflectionUtils.CreateGenericList(this.intType);

			list.AddWithReflection(stringType.GetMember("Empty"));
		}

		[TestMethod]
		public void AddIWithReflection_String()
		{
			var list = ReflectionUtils.CreateGenericList(this.stringType);

			list.AddWithReflection(Activator.CreateInstance(this.stringType, 'a', 3));

			Assert.IsTrue(list.Contains("aaa"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddIWithReflection_String_ThrowException()
		{
			var list = ReflectionUtils.CreateGenericList(this.stringType);

			list.AddWithReflection(Activator.CreateInstance(this.intType));
		}
	}
}
