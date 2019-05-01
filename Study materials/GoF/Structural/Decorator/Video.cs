namespace GoF.Structural.Decorator
{
    class Video : LibraryItem
    {
        public string Director { get; }
        public string Title { get; }
        public int PlayTime { get; }

        public Video(string director, string title,
            int numCopies, int playTime)
        {
            Director = director;
            Title = title;
            NumCopies = numCopies;
            PlayTime = playTime;
        }
    }
}