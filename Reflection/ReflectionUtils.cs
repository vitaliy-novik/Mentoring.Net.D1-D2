using System;
using System.Collections.Generic;

namespace Reflection
{
	public static class ReflectionUtils
	{
		public static List<T> CreateList<T>()
		{
			Type paramType = typeof(T);
			Type listType = typeof(List<T>);

			//Type constructedListType = listType.MakeGenericType(paramType);
			List<T> instance = (List<T>)Activator.CreateInstance(listType);

			return instance;
		}

		public static void AddListItem<T>(List<T> list, T item)
		{
			Type listType = list.GetType();
			listType.GetMethod("Add").Invoke(list, new [] { (object)item });
		}
	}
}
