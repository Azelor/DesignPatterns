using System;
using System.Collections.Generic;

namespace GoF.Behavioral.Visitor
{
    public class Employees {
        private readonly List<Employee> employees = new List<Employee>();

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void Attach(Employee employee) { employees.Add(employee); }
        public void Detach(Employee employee) { employees.Remove(employee); }
        public void Accept(IVisitor visitor) {
            foreach(var e in employees) { e.Accept(visitor); }
            Console.WriteLine();
        }
    }
}