using System;
using System.Collections;
using System.Collections.Generic;

namespace Reflection
{
	public static class ReflectionUtils
	{
		public static event EventHandler TestEvent;

		public static IList CreateGenericList(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException(nameof(type));
			}

			Type listType = typeof(List<>);
			Type genericListType = listType.MakeGenericType(type);

			return (IList)Activator.CreateInstance(genericListType);
		}

		public static void AddWithReflection(this IList list, object item)
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}

			Type listType = list.GetType();
			listType.GetMethod("Add").Invoke(list, new [] { item });
		}

		public void RaiseEvent()
		{
			TestEvent(this, EventArgs.Empty);
		}
	}
}
