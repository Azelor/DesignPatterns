using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdapterPattern;
using System.Linq;

namespace AdapterTestProject
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IStudentList adapter = new StudentAdapter();
            
            StudentData firstStudent = new StudentData();
            firstStudent.Id = 1;
            firstStudent.FirstName = "Tom";
            firstStudent.LastName = "Plank";
            firstStudent.StudentCode = "006116";
            firstStudent.ProgrammeCode = "IABB";
            firstStudent.ProgrammeName = "Business Information Technology";
            firstStudent.Faculty = "Information Technologies";
            
            adapter.AddStudent(firstStudent);
            
            Assert.AreEqual(adapter.GetStudents().First().ID, 1);
            Assert.AreEqual(adapter.GetStudents().First().Name, "Tom Plank");
            Assert.AreEqual(adapter.GetStudents().First().StudentIdentifier, "006116IABB");
            Assert.AreEqual(adapter.GetStudents().First().Programme, "Business Information Technology");
            Assert.AreEqual(adapter.GetStudents().First().Faculty, "Information Technologies");
        }
    }
}