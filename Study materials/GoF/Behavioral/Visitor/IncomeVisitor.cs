namespace GoF.Behavioral.Visitor
{
    public class IncomeVisitor : IVisitor {
        public void Visit(Element element)
        {
            var employee = element as Employee;
            if (employee != null) employee.Income *= 1.10;
        }
    }
}