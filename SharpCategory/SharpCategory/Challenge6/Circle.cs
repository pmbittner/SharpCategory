using System;

namespace SharpCategory.Challenge6
{
    public class Circle : Shape
    {
        public Circle(float radius) => Radius = radius;
        
        public float Radius { get; }

        public float Area() => Radius * Radius;
        public float Circ() => (float)(2.0 * Radius * Math.PI);
    }
}