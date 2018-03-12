using System.Collections.Generic;

namespace AdapterPattern
{
    public interface IStudentList
    {
        List<Student> GetStudents();
        void AddStudent(StudentData student);
    }
}