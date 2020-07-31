namespace SharpCategory.Challenge6
{
    public interface Shape
    {
        public float Area();

        // Adding this method requires to alter all implementing classes, i.e. Circle and Rect.
        public float Circ();
    }
}