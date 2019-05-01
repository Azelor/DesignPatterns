namespace GoF.Creational.FactoryMethod
{
    class Resume : Document
    {
        protected override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
}