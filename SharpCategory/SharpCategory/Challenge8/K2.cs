namespace SharpCategory.Challenge8
{
    public class K2<C, A, B>
    {
        public K2(C c)
        {
            Value = c;
        }

        public C Value
        {
            get;
        }

        public K2<C, D, E> Bimap<D, E>(Function<A, D> g, Function<B, E> h)
        {
            return new K2<C, D, E>(Value);
        }
    }
}