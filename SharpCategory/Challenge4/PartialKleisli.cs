namespace SharpCategory.Challenge4
{
    public partial class PartialKleisli
    {
        public static Maybe<T> Identity<T>(T x)
        {
            return new Maybe<T>(x);
        }

        public static Function<A, Maybe<C>> Composition<A, B, C>(Function<A, Maybe<B>> f, Function<B, Maybe<C>> g)
        {
            return a =>
            {
                Maybe<B> fa = f(a);
                return fa.IsValid ? g(fa.Value) : new Maybe<C>();
            };
        }
    }
}