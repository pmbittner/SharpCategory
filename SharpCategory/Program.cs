using System;
using System.Collections.Generic;

namespace SharpCategory
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge[] challenges =
            {
                new Challenge1.Challenge(),
                new Challenge2.Challenge(),
                new Challenge4.Challenge()
            };

            foreach (Challenge c in challenges)
            {
                Console.WriteLine($"=== Running Challenge {c.ChapterNo} =============================================");
                c.Run();
                Console.WriteLine();
            }
        }
    }
}