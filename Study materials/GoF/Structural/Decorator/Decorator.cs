namespace GoF.Structural.Decorator
{
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;
        
        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }
    }
}
