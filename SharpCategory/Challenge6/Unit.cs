namespace SharpCategory.Challenge6
{
    public class Unit
    {
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