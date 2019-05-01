using GoF.Structural.Decorator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class DecoratorTests
    {
        private Borrowable borrowableVideo;
        private Video video;
        private string customer;

        [TestInitialize]
        public void Initialize()
        {
            video = new Video("Spielberg", "Jaws", 23, 92);
            borrowableVideo = new Borrowable(video);
            customer = "Customer #1";
        }

        [TestMethod]
        public void BorrowableItemHasCorrectMethodTest()
        {
            Assert.IsFalse(HasMethod(video, "BorrowItem"));
            Assert.IsTrue(HasMethod(borrowableVideo, "BorrowItem"));
        }

        [TestMethod]
        public void BorrowItemTest()
        {
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            Borrowable borrowableBook = new Borrowable(book);

            int initialAvailableCopies = book.NumCopies;
            borrowableBook.BorrowItem(customer);

            // TODO: V2lja kirjutada ka see et decorator 
            Assert.AreEqual(initialAvailableCopies - 1, book.NumCopies);
            CollectionAssert.Contains(borrowableBook.Borrowers, customer);
        }

        [TestMethod]
        public void ReturnItemTest()
        {
            borrowableVideo.Borrowers.Add(customer);

            int initialAvailableCopies = video.NumCopies;
            borrowableVideo.ReturnItem(customer);

            Assert.AreEqual(initialAvailableCopies + 1, video.NumCopies);
            CollectionAssert.DoesNotContain(borrowableVideo.Borrowers, customer);
        }

        // j2tta sisse sellep2rast, et n2idata kuidas meetodi olemasolu kontrollitakse (reflektsioon). muidu m6ttetu test. 
        private bool HasMethod(LibraryItem objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }
    }
}