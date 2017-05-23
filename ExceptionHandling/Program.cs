using System;

namespace ExceptionHandling
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Enter any symbols:");
				string input = Console.ReadLine();
				try
				{
					string output = TruncateInput(input);
					Console.WriteLine(output);
				}
				catch (EmptyInputException exception)
				{
					Console.WriteLine(exception.Message);
				}
			}
		}

		static string TruncateInput(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new EmptyInputException();
			}

			return input.Substring(0, 1);
		}
	}
}
