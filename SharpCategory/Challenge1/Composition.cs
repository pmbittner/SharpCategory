using System;

namespace SharpCategory.Challenge1
{
    public static partial class Functions
    {
        public static Function<A, C> Composition<A, B, C>(Function<A, B> f, Function<B, C> g)
        {
            return x => g(f(x));
        }
    }
}