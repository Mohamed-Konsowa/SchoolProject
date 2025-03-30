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
        public async Task<Student> GetStudentByIDWithIncludeAsync(int id)
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

        public async Task<bool> IsNameExistsAsync(string name)
        {
            var student = _studentRepository.GetTableNoTracking()
                .Where(s => s.Name.Equals(name)).FirstOrDefault();
 
            return (student is not null);
        }
        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Falied";
            }

        }

        public async Task<Student> GetByIDAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }
        #endregion

    }
}
