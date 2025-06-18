using Microsoft.Extensions.DependencyInjection;
namespace SchoolProject.Infrastructure
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
        {
            // moved to presentation layer
            //services.AddIdentity<User, IdentityRole<int>>(option =>
            //{
            //    // Password settings.
                
            //    // Lockout settings.
                
            //    // User settings.
            //}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
