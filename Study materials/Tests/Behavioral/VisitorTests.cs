using GoF.Behavioral.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Behavioral {

    [TestClass]
    public class VisitorTests
    {
        private Employees employees;
        private Employee clerk;
        private Employee director;
        private Employee president;

        [TestInitialize]
        public void Initialize()
        {
            employees = new Employees();
            clerk = new Clerk();
            director = new Director();
            president = new President();

            employees.Attach(clerk);
            employees.Attach(director);
            employees.Attach(president);
        }

        [TestMethod]
        public void AttachingEmployeesTest() {
            var e = new Employees();
            e.Attach(clerk);
            e.Attach(director);
            e.Attach(president);

            Assert.AreEqual(e.GetEmployees()[0], clerk);
            Assert.AreEqual(e.GetEmployees()[1], director);
            Assert.AreEqual(e.GetEmployees()[2], president);
        }

        [TestMethod]
        public void DetachingEmployeesTest()
        {
            employees.Detach(clerk);

            Assert.AreEqual(employees.GetEmployees()[0], director);
            Assert.AreEqual(employees.GetEmployees()[1], president);
        }

        [TestMethod]
        public void IncomeVisitorTest()
        {
            double clerkIncome = clerk.Income;
            double directorIncome = director.Income;
            double presidentIncome = president.Income;

            employees.Accept(new IncomeVisitor());

            Assert.AreEqual(clerkIncome * 1.10, clerk.Income);
            Assert.AreEqual(directorIncome * 1.10, director.Income);
            Assert.AreEqual(presidentIncome * 1.10, president.Income);
        }

        [TestMethod]
        public void VacationVisitorTest()
        {
            int clerkVacationDays = clerk.VacationDays;
            int directorVacationDays = director.VacationDays;
            int presidentVacationDays = president.VacationDays;

            employees.Accept(new VacationVisitor());

            Assert.AreEqual(clerkVacationDays + 3, clerk.VacationDays);
            Assert.AreEqual(directorVacationDays + 3, director.VacationDays);
            Assert.AreEqual(presidentVacationDays + 3, president.VacationDays);
        }
    }
}
