namespace GoF.Structural.Decorator
{
    class Book : LibraryItem
    {
        public string Author { get; }
        public string Title { get; }

        public Book(string author, string title, int numCopies)
        {
            Author = author;
            Title = title;
            NumCopies = numCopies;
        }
    }
}