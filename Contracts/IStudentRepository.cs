using StudentManagement.Models;

namespace StudentManagement.Contracts
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetStudents();

        public Task<Student>  GetStudentById(int id);

        public Task<Student> GetLeavePercentage(int id);

        public Task<IEnumerable<Student>> GetParentDetails();

        public Task<IEnumerable<Student>> GetStudentGradeWise();

        public Task DeleteStudent(int id);

        public Task UpdateStudent(int id,Student student);

        public Task<Student> AddStudent(Student student);
    }
}
