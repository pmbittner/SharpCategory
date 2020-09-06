using System;
using System.Collections.Generic;

namespace SharpCategory.Challenge2
{
    public static partial class Functions
    {
        private class Memorizer<T, R>
        {
            private Function<T, R> Implementation { get; }
            private Dictionary<T, R> Memory { get; }

            internal Memorizer(Function<T, R> implementation)
            {
                Implementation = implementation;
                Memory = new Dictionary<T, R>();
            }
            
            public R Compute(T val)
            {
                if (Memory.TryGetValue(val, out R r))
                {
                    return r;
                }

                return Memory[val] = Implementation(val);
            }
        }
        
        public static Function<T, R> Memoize<T, R>(Function<T, R> f)
        {
            return new Memorizer<T, R>(f).Compute;
        }
    }
}