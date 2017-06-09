using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Reflection.Tests
{
	[TestClass]
	public class ReflectionUtilsTest
	{
		readonly Type stringType = Type.GetType("System.String");
		readonly Type intType = Type.GetType("System.Int32");
		private bool methodInvocationFlag;

		[TestInitialize]
		public void Initialize()
		{
			this.methodInvocationFlag = false;
		}

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

		[TestMethod]
		public void SubscribeToEvent()
		{
			EventPublisher publisher = new EventPublisher();
			ReflectionUtils.SubscribeToEvent(publisher, "TestEvent", this, "TestMethod");

			publisher.RaiseEvent();

			Assert.IsTrue(this.methodInvocationFlag);
		}

		public void TestMethod(object sender, EventArgs args)
		{
			this.methodInvocationFlag = true;
		}
	}
}
