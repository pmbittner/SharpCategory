namespace SharpCategory
{
    public interface Challenge
    {
        public int ChapterNo { get; protected set; }
        
        public void Run();
    }
}