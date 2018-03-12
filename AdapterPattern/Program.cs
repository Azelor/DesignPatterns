using System;
using System.Collections.Generic;
using System.Linq;

namespace AdapterPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IStudentList adapter = new StudentAdapter();
            
            StudentData student1 = new StudentData();
            student1.Id = 1;
            student1.FirstName = "Tom";
            student1.LastName = "Plank";
            student1.StudentCode = "006116";
            student1.ProgrammeCode = "IABB";
            student1.ProgrammeName = "Business Information Technology";
            student1.Faculty = "Information Technologies";
            
            adapter.AddStudent(student1);
            
            Console.WriteLine("Students:");
            Console.WriteLine(adapter.GetStudents().First().ID);
            Console.WriteLine(adapter.GetStudents().First().Name);
            Console.WriteLine(adapter.GetStudents().First().StudentIdentifier);
            Console.WriteLine(adapter.GetStudents().First().Programme);
            Console.WriteLine(adapter.GetStudents().First().Faculty);
        }
    }
}