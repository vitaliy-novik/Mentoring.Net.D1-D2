namespace FibonacciNumbers
{
	public interface IFibonacciCache
	{
		int Get(int index);

		void Set(int index, int value);

		bool IsCached(int index);
	}
}
