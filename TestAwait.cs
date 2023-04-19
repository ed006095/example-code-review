using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TestAwait
    {
        public TestAwait()
        {
            Something();
        }

        public void Something()
        {
            var t = SomethingAsync();
            Console.WriteLine("Method returned"); //
            t.Wait();
            Console.WriteLine("Task waited"); //

        }
        public async Task SomethingAsync()
        {
            Console.WriteLine("About to fetch static data from cache"); //
            await Task.FromResult(42);
            Console.WriteLine("Fetching market data..."); //
            await Task.Delay(1000);
            Console.WriteLine("Market data fetched"); //
        }
    }
}
