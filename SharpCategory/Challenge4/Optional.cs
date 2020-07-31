namespace SharpCategory.Challenge4
{
    public class Optional<T>
    {
        public Optional()
        {
            isValid = false;
        }

        public Optional(T value)
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