using SharpCategory.Challenge7;

namespace SharpCategory.Challenge4
{
    public class Maybe<T>
    {
        public Maybe()
        {
            IsValid = false;
        }

        public Maybe(T value)
        {
            IsValid = true;
            Value = value;
        }

        public bool IsValid
        {
            get;
        }

        public T Value
        {
            get;
        }

        public override string ToString()
        {
            return IsValid ? "Just " + Value : "Nothing";
        }
    }
}