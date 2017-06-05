using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{
	[Serializable]
	class EmptyInputException : Exception
	{
		private const string ErrorMessage = "Input can not be empty";

		public EmptyInputException() : base(ErrorMessage) { }

		public EmptyInputException(string message) : base(message) { }

		public EmptyInputException(string message, Exception innerException) : base(message, innerException) { }

		protected EmptyInputException(SerializationInfo info, StreamingContext context) : base(info, context){ }

		public override string Message => string.IsNullOrEmpty(base.Message) ? ErrorMessage : base.Message;
	}
}
