using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentByIdAsync(int id);
    }
}
