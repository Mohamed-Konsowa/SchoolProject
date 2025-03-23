using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion
        #region Constructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        #endregion
        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                                  .Include(s => s.Department)
                                                  .Where(s => s.StudID == id)
                                                  .FirstOrDefaultAsync();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //
            var studentResult = _studentRepository.GetTableNoTracking()
                                                  .Where(s => s.Name == student.Name)
                                                  .FirstOrDefault();
            if (studentResult != null) return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        #endregion

    }
}
