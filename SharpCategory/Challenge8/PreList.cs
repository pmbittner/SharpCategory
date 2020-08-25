using System;

namespace SharpCategory.Challenge8
{
    public class PreList<A, B>
    {
        private A head;
        private B tail;
        
        public PreList(bool empty)
        {
            IsEmpty = empty;
        }
        
        public bool IsEmpty { get; }

        public A Head
        {
            get
            {
                if (!IsEmpty)
                {
                    return head;
                }
                
                throw new FieldAccessException($"This instance of PreList<{typeof(A)}, {typeof(B)}> is not empty!");
            }
        }

        public B Tail
        {
            get
            {
                if (!IsEmpty)
                {
                    return tail;
                }
                
                throw new FieldAccessException($"This instance of PreList<{typeof(A)}, {typeof(B)}> is not empty!");
            }
        }

        public static PreList<X, Y> ConsEmpty<X, Y>()
        {
            return new PreList<X, Y>(true);
        }

        public static PreList<X, Y> ConsValued<X, Y>(X head, Y tail)
        {
            return new PreList<X, Y>(false) {head = head, tail = tail};
        }

        public PreList<C, D> Bimap<C, D>(Function<A, C> g, Function<B, D> h)
        {
            if (IsEmpty)
            {
                return ConsEmpty<C, D>();
            }

            return ConsValued(g(Head), h(Tail));
        }
    }
}