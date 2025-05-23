﻿using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBase;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetStudentsListAsync();
    }
}
