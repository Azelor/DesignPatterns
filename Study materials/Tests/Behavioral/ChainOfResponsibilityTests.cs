using GoF.Aids;
using GoF.Behavioral.ChainOfResponsibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Behavioral
{
    [TestClass]
    public class ChainOfResponsibilityTests {
        private const double tenThousand = 10000;
        private const double hundredThousand = 100000;
        private const double oneMillion = 1000000;

        private Department department;
        private Board board;
        private President president;
        private Director director;
        private Manager manager;

        private LogBook logBook;
        private string purpose;
        private int number;

        [TestInitialize] public void Initialize() {
            board = new Board();
            president = new President(board, oneMillion);
            director = new Director(president, hundredThousand);
            manager = new Manager(director, tenThousand);
            department = new Department(manager);
            logBook = new LogBook();
            number = GetRandom.Int16(0);
            purpose = GetRandom.String();
        }

        [TestMethod] public void ApprovedByManagerTest() {
            TestApproval(manager, double.Epsilon, tenThousand);
        }

        [TestMethod] public void ApprovedByDirectorTest() {
            TestApproval(director, tenThousand, hundredThousand);
        }

        [TestMethod] public void ApprovedByPresidentTest() {
            TestApproval(president, hundredThousand, oneMillion);
        }

        [TestMethod] public void ApprovedByBoardTest() {
            TestApproval(board, oneMillion);
        }

        private void TestApproval(Approver approver, double min, double max = double.MaxValue) {
            var amount = GetRandom.Double(min, max);
            var p = new Purchase(number, amount, purpose);

            department.Approve(p, logBook);

            Assert.AreEqual(approver.ApprovalMsg(number, purpose), logBook.ReadLine());
        }
    }
}
