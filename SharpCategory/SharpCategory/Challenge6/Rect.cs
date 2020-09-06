namespace SharpCategory.Challenge6
{
    public class Rect : Shape
    {
        public Rect(float width, float height)
        {
            Width = width;
            Height = height;
        }
        
        public float Width { get; }
        public float Height { get; }

        public float Area() => Width * Height;
        public float Circ() => 2 * (Width + Height);
    }
}