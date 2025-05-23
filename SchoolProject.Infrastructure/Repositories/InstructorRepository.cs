﻿
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields
        private readonly DbSet<Instructor> _instructors;
        #endregion

        #region Constructors
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            _instructors = context.Set<Instructor>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
