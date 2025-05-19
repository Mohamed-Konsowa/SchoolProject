using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        #region Handle Functions
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department =  await _departmentRepository.GetTableNoTracking().Where(d => d.DID == id)
                                                             .Include(d => d.DepartmentSubjects).ThenInclude(ds => ds.Subject)
                                                             .Include(d => d.Students)
                                                             .Include(d => d.Instructors)
                                                             .Include(d => d.Manager)
                                                             .FirstOrDefaultAsync();
            return department;
        }
        #endregion
    }
}
