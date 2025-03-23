using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student> GetStudentByIdAsync(int id);
    }
}
