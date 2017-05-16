using StackExchange.Redis;

namespace FibonacciNumbers
{
	public class FibonacciRedisCache : IFibonacciCache
	{
		private ConnectionMultiplexer redisConnection;
		private const string Prefix = "Fibonacci";
		private const string MaxValueKey = "LastIndex";

		public FibonacciRedisCache(string hostName)
		{
			redisConnection = ConnectionMultiplexer.Connect(hostName);
		}

		public int Get(int index)
		{
			IDatabase db = redisConnection.GetDatabase();
			return (int)db.StringGet(Prefix + index);

		}

		public void Set(int index, int value)
		{
			IDatabase db = redisConnection.GetDatabase();
			db.StringSet(Prefix + index, value);
			db.StringSet(Prefix + MaxValueKey, index);
		}

		public int GetLastIndex()
		{
			IDatabase db = redisConnection.GetDatabase();
			return (int)db.StringGet(Prefix + MaxValueKey);
		}
	}
}
