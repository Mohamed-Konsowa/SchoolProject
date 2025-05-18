using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.InfrastructureBase;
using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection Services)
        {
            Services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            Services.AddTransient<IStudentRepository, StudentRepository>();
            Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            Services.AddTransient<IInstructorRepository, InstructorRepository>();
            Services.AddTransient<ISubjectRepository, SubjectRepository>();
            return Services;
        }
    }
}
