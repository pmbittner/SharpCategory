namespace SharpCategory.Challenge7
{
    public class Reader<R>
    {
        public static Function<Function<R, A>, Function<R, B>> fmap<A, B>(Function<A, B> f) 
            => reader => Challenge1.Functions.Composition(f, reader);

        public static Function<R, B> fmap_curried<A, B>(Function<R, A> reader, Function<A, B> f) 
            => Challenge1.Functions.Composition(f, reader);
    }
}