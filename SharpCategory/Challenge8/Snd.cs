namespace SharpCategory.Challenge8
{
    public class Snd<A, B>
    {
        public Snd(B a)
        {
            Value = a;
        }
        
        public B Value { get; }

        public Snd<C, D> Bimap<C, D>(Function<A, C> g, Function<B, D> h)
        {
            return new Snd<C, D>(h(Value));
        }
    }
}