using System;
using System.Collections;
using System.Collections.Generic;

namespace Reflection
{
	public static class ReflectionUtils
	{
		public static IList CreateGenericList(Type type)
		{
			Type listType = typeof(List<>);
			Type genericListType = listType.MakeGenericType(type);

			return (IList)Activator.CreateInstance(genericListType);
		}

		public static object CreateInstance(Type type, params object[] args)
		{
			//try
			//{
				return Activator.CreateInstance(type, args);
			//}
			//catch (Exception e)
			//{
			//	throw;
			//}
		}

		public static void AddWithReflection(this IList list, object item)
		{
			Type listType = list.GetType();
			listType.GetMethod("Add").Invoke(list, new [] { item });
		}
	}
}
