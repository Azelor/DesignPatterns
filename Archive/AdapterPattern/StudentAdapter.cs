using System.Collections.Generic;

namespace AdapterPattern
{
    public class StudentAdapter : IStudentList
    {
        private List<Student> Students = new List<Student>();
        
        public List<Student> GetStudents()
        {
            return Students;
        }

        public void AddStudent(StudentData student)
        {
            Students.Add(new Student
                {
                    ID = student.Id,
                    Name = student.FirstName + " " + student.LastName,
                    StudentIdentifier = student.StudentCode + student.ProgrammeCode,
                    Programme = student.ProgrammeName,
                    Faculty = student.Faculty
                });
        }
    }
}