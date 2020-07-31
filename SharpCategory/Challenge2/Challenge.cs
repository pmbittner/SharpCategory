using System;
using System.Collections.Generic;

namespace SharpCategory.Challenge2
{
    public class Challenge : SharpCategory.Challenge
    {
        int SharpCategory.Challenge.ChapterNo { get; } = 2;
        
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
            
            // Run all functions from bool to bool
            var allBoolFunctions = new Dictionary<string, Function<bool, bool>>
            {
                {"True", x => true},
                {"False", x => false},
                {"Id", x => x},
                {"Not", x => !x}
            };

            foreach (KeyValuePair<string, Function<bool, bool>> f in allBoolFunctions)
            {
                foreach (bool b in new []{true, false})
                {
                    Console.WriteLine($"{f.Key}({b}) -> {f.Value(b)}");
                }
            }
        }
    }
}