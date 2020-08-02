using System;

namespace SharpCategory.Challenge1
{
    public static partial class Functions
    {
        public static Function<A, C> Composition<A, B, C>(Function<B, C> g, Function<A, B> f)
        {
            return x => g(f(x));
        }
    }
}