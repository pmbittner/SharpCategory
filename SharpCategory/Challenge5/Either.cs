using System;

namespace SharpCategory.Challenge5
{
    public class Either<A, B>
    {
        private A a;
        private B b;

        private Either(bool isLeft) => IsLeft = isLeft;
        
        public static Either<A, B> ConsLeft(A a)
        {
            return new Either<A, B>(true)
            {
                a = a
            };
        }
        
        public static Either<A, B> ConsRight(B b)
        {
            return new Either<A, B>(false)
            {
                b = b
            };
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

        public override string ToString()
        {
            string t = IsLeft ? "Left[" : "Right[";
            return t + (IsLeft ? Left.ToString() : Right.ToString()) + "]";
        }
    }
}