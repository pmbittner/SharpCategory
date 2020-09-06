namespace SharpCategory.Challenge6
{
    /*
     * Task 4: Adding this class does not require modification if we let it inherit from Rect.
     * If we instead lead it implement Shape directly, we had to implement its methods Area and Circ again.
     */
    public class Square : Rect
    {
        public Square(float width) : base(width, width) {}
    }
}