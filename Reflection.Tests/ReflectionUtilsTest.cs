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
			var list = ReflectionUtils.CreateInstance(this.stringType);

			Assert.AreEqual(typeof(List<string>), list.GetType());
		}

		[TestMethod]
		public void CreateInstance_Int()
		{
			var instance = ReflectionUtils.CreateInstance(this.intType);

			Assert.AreEqual(typeof(int), instance.GetType());
		}

		[TestMethod]
		public void CreateInstance_String()
		{
			var instance = ReflectionUtils.CreateInstance(this.stringType);

			Assert.AreEqual(typeof(string), instance.GetType());
		}

		[TestMethod]
		public void AddIWithReflection_Int()
		{
			var list = ReflectionUtils.CreateGenericList(this.intType);
			
			list.AddWithReflection(4);

			Assert.IsTrue(list.Contains(4));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddIWithReflection_Int_Throwexception()
		{
			var list = ReflectionUtils.CreateGenericList(this.intType);

			list.AddWithReflection("a");
		}

		[TestMethod]
		public void AddIWithReflection_String()
		{
			var stringType = Type.GetType("System.String");
			var list = ReflectionUtils.CreateGenericList(this.stringType);

			list.AddWithReflection("a");

			Assert.IsTrue(list.Contains("a"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddIWithReflection_String_Throwexception()
		{
			var list = ReflectionUtils.CreateGenericList(this.stringType);

			list.AddWithReflection(12);
		}
	}
}
