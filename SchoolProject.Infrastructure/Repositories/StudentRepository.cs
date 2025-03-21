using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbcontext;

        #endregion

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dbcontext.students.ToListAsync();
        }

        #endregion
    }
}
