using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student> GetStudentByIDWithIncludeAsync(int id);
        public Task<Student> GetByIDAsync(int id);
        Task<string> AddAsync(Student student);
        Task<bool> IsNameExistsAsync(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> FilterStudentPaginatedQueryable(SudentOrderingEnum orderEnum, string search);
    }
}
