using System;

namespace SharpCategory.Challenge8
{
    public class Identity<T>
    {
        public Identity(T val)
        {
            Value = val;
        }

        public T Value
        {
            get;
        }

        public Identity<B> fmap<B>(Function<T, B> f)
        {
            return new Identity<B>(f(Value));
        }
    }
}