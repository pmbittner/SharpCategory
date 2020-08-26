namespace SharpCategory.Challenge8
{
    public class Fst<A, B>
    {
        public Fst(A a)
        {
            Value = a;
        }
        
        public A Value { get; }

        public Fst<C, D> Bimap<C, D>(Function<A, C> g, Function<B, D> h)
        {
            return new Fst<C, D>(g(Value));
        }
    }
}