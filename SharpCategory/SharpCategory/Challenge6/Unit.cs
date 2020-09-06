#nullable enable
namespace SharpCategory.Challenge6
{
    public class Unit
    {
        private Unit() {}

        public static Unit Instance { get; } = new Unit();
        
        public override bool Equals(object? obj)
        {
            return obj is Unit;
        }

        public static bool operator ==(Unit a, Unit b)
        {
            return true;
        }
        
        public static bool operator !=(Unit a, Unit b)
        {
            return false;
        }

        public override string ToString()
        {
            return "()";
        }
    }
}