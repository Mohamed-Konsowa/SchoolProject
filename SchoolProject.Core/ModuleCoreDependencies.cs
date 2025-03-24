using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection Services)
        {
            //Configuration of mediator
            Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration of automapper
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            
            return Services;
        }
    }
}
