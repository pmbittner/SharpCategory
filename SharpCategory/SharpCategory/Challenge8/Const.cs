namespace SharpCategory.Challenge8
{
    public class Const<C, A>
    {
        public Const(C c)
        {
            Value = c;
        }

        public C Value
        {
            get;
        }

        public Const<C, B> fmap<B>(Function<A, B> f)
        {
            return new Const<C, B>(Value);
        }

        public override string ToString()
        {
            return $"Const<{typeof(C).Name}, {typeof(A).Name}>[{Value}]";
        }
    }
}