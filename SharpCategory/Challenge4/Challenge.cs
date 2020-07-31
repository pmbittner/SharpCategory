using System;

namespace SharpCategory.Challenge4
{
    public class Challenge : SharpCategory.Challenge
    {
        int SharpCategory.Challenge.ChapterNo { get; set; } = 4;
        
        Optional<double> safe_root(double x)
        {
            return x >= 0 ? new Optional<double>(Math.Sqrt(x)) : new Optional<double>();
        }
        
        Optional<double> safe_reciprocal(double x)
        {
            return x != 0.0 ? new Optional<double>(1.0 / x) : new Optional<double>();
        }

        public void Run()
        {
            Function<double, Optional<double>> safe_root_reciprocal =
                PartialKleisli.Composition<double, double, double>(safe_reciprocal, safe_root);

            double[] testArguments = {1.0, 0.0, -1.0, 0.25};
            foreach (double x in testArguments)
            {
                Console.WriteLine($"  id({x})   = {PartialKleisli.Identity(x)}");
                Console.WriteLine($"sqrt(1/{x}) = {safe_root_reciprocal(x)}");
            }
        }
    }
}