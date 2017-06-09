using System;

namespace Reflection
{
	public class EventPublisher
	{
		public event EventHandler TestEvent;

		public void RaiseEvent()
		{
			TestEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
