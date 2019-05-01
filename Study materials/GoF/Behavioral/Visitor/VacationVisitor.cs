namespace GoF.Behavioral.Visitor
{
    public class VacationVisitor : IVisitor {
        public void Visit(Element element) {
            var employee = element as Employee;
            employee.VacationDays += 3;
        }
    }
}