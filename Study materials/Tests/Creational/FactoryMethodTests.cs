using GoF.Creational.FactoryMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Creational
{
    [TestClass]
    public class FactoryMethodTests
    {
        [TestMethod]
        public void ReportFactoryTest()
        {
            var report = new Report();

            Assert.AreEqual(report.Pages.Count, 5);
            Assert.IsInstanceOfType(report.Pages[0], typeof(IntroductionPage));
            Assert.IsInstanceOfType(report.Pages[1], typeof(ResultsPage));
            Assert.IsInstanceOfType(report.Pages[2], typeof(ConclusionPage));
            Assert.IsInstanceOfType(report.Pages[3], typeof(SummaryPage));
            Assert.IsInstanceOfType(report.Pages[4], typeof(BibliographyPage));
        }

        [TestMethod]
        public void ResumeFactoryTest()
        {
            var resume = new Resume();
            
            Assert.AreEqual(resume.Pages.Count, 3);
            Assert.IsInstanceOfType(resume.Pages[0], typeof(SkillsPage));
            Assert.IsInstanceOfType(resume.Pages[1], typeof(EducationPage));
            Assert.IsInstanceOfType(resume.Pages[2], typeof(ExperiencePage));
        }
    }
}
