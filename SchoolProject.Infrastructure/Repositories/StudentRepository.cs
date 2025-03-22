using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        //private readonly ApplicationDbContext _dbcontext;
        private readonly DbSet<Student> _students;

        #endregion

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //_dbcontext = dbContext;
            _students = dbContext.Set<Student>();
        }

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(s => s.Department).ToListAsync();
        }

        #endregion
    }
}
