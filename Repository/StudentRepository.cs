using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Repository
{

    public sealed class StudentRepository : IStudent
    {
        private readonly List<Student> students;

        public StudentRepository(List<Student> students)
        {
            this.students = students;
        }

        public IEnumerable<Student> GetStudents()
        {
            if (students?.Count > 0)
                return students.ToArray();
            else
                return Enumerable.Empty<Student>();
        }

        public Student GetStudentById(int id)
        {
            return students?.FirstOrDefault(x => x.Id == id) ?? new Student();
        }

        public bool SaveStudent(Student student)
        {
            try
            {
                int maxId = 0;
                if (students?.Count > 0)
                    maxId = students.Max(x => x.Id) + 1;
                student.Id = maxId;
                students?.Add(student);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                bool result = false;
                int studentIndex = -1;
                if (students?.Count > 0)
                    studentIndex = students?.FindIndex(x => x.Id == student.Id) ?? -1;
                if (studentIndex <= -1)
                    result = false;
                else
                {
                    if (students?.Count > 0)
                    {
                        students[studentIndex].FirstName = student.FirstName;
                        students[studentIndex].LastName = student.LastName;
                        students[studentIndex].Age = student.Age;
                        students[studentIndex].Gender = student.Gender;
                        students[studentIndex].Address = student.Address;
                        students[studentIndex].Class = student.Class;
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudentById(int id)
        {
            try
            {
                bool result = false;
                int studentIndex = -1;
                if (students?.Count > 0)
                    studentIndex = students?.FindIndex(x => x.Id == id) ?? -1;
                if (studentIndex == -1)
                    result = false;
                else
                {
                    if (students?.Count > 0)
                    {
                        students.RemoveAt(studentIndex);
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
