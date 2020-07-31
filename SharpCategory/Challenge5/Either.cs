using System;

namespace SharpCategory.Challenge5
{
    public class Either<A, B>
    {
        private A a;
        private B b;
        
        public Either(A a)
        {
            IsLeft = true;
            this.a = a;
        }

        public Either(B b)
        {
            IsLeft = false;
            this.b = b;
        }
        
        public bool IsLeft { get; }

        public A Left
        {
            get
            {
                if (IsLeft)
                {
                    return a;
                }
                
                throw new FieldAccessException($"This instance of Either<{typeof(A)}, {typeof(B)}> is not an {typeof(A)}!");
            }
        }

        public B Right
        {
            get
            {
                if (!IsLeft)
                {
                    return b;
                }
                
                throw new FieldAccessException($"This instance of Either<{typeof(A)}, {typeof(B)}> is not an {typeof(B)}!");
            }
        }
    }
}