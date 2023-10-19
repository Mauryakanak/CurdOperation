using DemoProject.Models;
using System.Collections.Generic;

namespace DemoProject.Repository
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        bool SaveStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudentById(int id);
    }
}
