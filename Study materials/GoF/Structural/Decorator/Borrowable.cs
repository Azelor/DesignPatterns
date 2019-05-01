using System.Collections.Generic;

namespace GoF.Structural.Decorator
{
    class Borrowable : Decorator
    {
        public List<string> Borrowers { get; } = new List<string>();

        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            Borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            Borrowers.Remove(name);
            libraryItem.NumCopies++;
        }
    }
}