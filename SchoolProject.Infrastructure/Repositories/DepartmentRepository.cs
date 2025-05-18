using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {

        #region Fields
        private readonly DbSet<Department> _departments;
        #endregion

        #region Constructors
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _departments = context.Set<Department>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
