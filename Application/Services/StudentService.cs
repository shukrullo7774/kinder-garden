using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<int> CreateStudent(Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "John Doe", Age = 20 },
                new Student { Id = 2, Name = "Jane Smith", Age = 22 }
                // Другие студенты...
            };
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            await Task.Delay(100);
            return _students;
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            await Task.Delay(100); 
            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public async Task<int> CreateStudent(Student student)
        {
            await Task.Delay(100); 
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
            return student.Id;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
