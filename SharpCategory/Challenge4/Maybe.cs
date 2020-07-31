namespace SharpCategory.Challenge4
{
    public class Maybe<T>
    {
        public Maybe()
        {
            isValid = false;
        }

        public Maybe(T value)
        {
            isValid = true;
            this.value = value;
        }

        public bool isValid
        {
            get;
        }

        public T value
        {
            get;
        }

        public override string ToString()
        {
            return isValid ? value.ToString() : "<invalid>";
        }
    }
}