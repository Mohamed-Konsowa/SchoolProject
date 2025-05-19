using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
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
                                                  .Where(s => s.NameAr == student.NameAr)
                                                  .FirstOrDefault();
            if (studentResult != null) return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameArExistsAsync(string nameAr)
        {
            var student = _studentRepository.GetTableNoTracking()
                .Where(s => s.NameAr.Equals(nameAr)).FirstOrDefault();
 
            return (student is not null);
        }
        public async Task<bool> IsNameEnExistsAsync(string nameEn)
        {
            var student = _studentRepository.GetTableNoTracking()
                .Where(s => s.NameEn.Equals(nameEn)).FirstOrDefault();

            return (student is not null);
        }
        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }
        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
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

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
        }

        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(s => s.DID.Equals(DID)).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQueryable(SudentOrderingEnum orderEnum, string search)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
            if(search is not null)
            {
                queryable = queryable.Where(s => s.NameAr.Contains(search) || s.Address.Contains(search));
            }
            switch (orderEnum)
            {
                case SudentOrderingEnum.StudId:
                    queryable = queryable.OrderBy(s => s.StudID);
                    break;
                case SudentOrderingEnum.Name:
                    queryable = queryable.OrderBy(s => s.NameAr);
                    break;
                case SudentOrderingEnum.Address:
                    queryable = queryable.OrderBy(s => s.Address);
                    break;
                case SudentOrderingEnum.DepartmentName:
                    queryable = queryable.OrderBy(s => s.Department.DNameAr);
                    break;
            }
            return queryable;
        }
        #endregion

    }
}
