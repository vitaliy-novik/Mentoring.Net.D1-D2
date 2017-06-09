using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
	public static class ReflectionUtils
	{
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

		public static void SubscribeToEvent(object publisherObject, string eventName, object handlerObject, string methodName)
		{
			EventInfo eventInfo = publisherObject.GetType().GetEvent(eventName);
			if (eventInfo == null)
			{
				throw new ArgumentException($"{nameof(publisherObject)} does not contain event {eventName}");
			}

			MethodInfo methodInfo = handlerObject.GetType().GetMethod(methodName);
			if (methodInfo == null)
			{
				throw new ArgumentException($"{nameof(handlerObject)} does not contain method {methodName}");
			}

			Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, handlerObject, methodInfo);
			eventInfo.AddEventHandler(publisherObject, handler);
		}
	}
}
