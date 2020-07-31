namespace SharpCategory.Challenge4
{
    public partial class PartialKleisli
    {
        public static Optional<T> Identity<T>(T x)
        {
            return new Optional<T>(x);
        }

        public static Function<A, Optional<C>> Composition<A, B, C>(Function<A, Optional<B>> f, Function<B, Optional<C>> g)
        {
            return a =>
            {
                Optional<B> fa = f(a);
                return fa.isValid ? g(fa.value) : new Optional<C>();
            };
        }
    }
}