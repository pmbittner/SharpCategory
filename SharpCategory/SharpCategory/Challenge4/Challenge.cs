using System;

namespace SharpCategory.Challenge4
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 4;
        
        Maybe<double> safe_root(double x)
        {
            return x >= 0 ? new Maybe<double>(Math.Sqrt(x)) : new Maybe<double>();
        }
        
        Maybe<double> safe_reciprocal(double x)
        {
            return x != 0.0 ? new Maybe<double>(1.0 / x) : new Maybe<double>();
        }

        public void Run()
        {
            Function<double, Maybe<double>> safe_root_reciprocal =
                PartialKleisli.Composition<double, double, double>(safe_reciprocal, safe_root);
            
            foreach (double x in new []{1.0, 0.0, -1.0, 0.25})
            {
                Console.WriteLine($"  id({x})   = {PartialKleisli.Identity(x)}");
                Console.WriteLine($"sqrt(1/{x}) = {safe_root_reciprocal(x)}");
            }
        }
    }
}