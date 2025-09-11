using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<IStudentService, StudentService>();
            Services.AddTransient<IDepartmentService, DepartmentService>();
            Services.AddTransient<IAuthenticationService, AuthenticationService>();
            Services.AddTransient<IAuthorizationService, AuthorizationService>();
            return Services;
        }
    }
}
