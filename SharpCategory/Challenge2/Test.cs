using System;

namespace SharpCategory.Challenge2
{
    public class Test : SharpCategory.Test
    {
        private static void TestMemoize<T, R>(Function<T, R> f, T val)
        {
            Function<T, R> fmem = Functions.Memoize(f);
            for (int i = 0; i < 5; ++i)
                Console.WriteLine($"f({val}) = {fmem(val)}");
            Console.WriteLine();
        }
        
        public void Run()
        {
            TestMemoize(x =>
            {
                Console.WriteLine("\nI was called and I am so expensive!");
                return x;
            }, 24);
            Random random = new Random();
            TestMemoize(random.Next, 12);
            TestMemoize(seed => new Random(seed).Next(), 10);
        }
    }
}