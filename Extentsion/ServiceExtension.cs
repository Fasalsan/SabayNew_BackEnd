using Microsoft.EntityFrameworkCore;
using SabayNew.Dal;
using SabayNew.Repository;
using SabayNew.Repository.Content;
using SabayNew.Repository.Role;
using SabayNew.Repository.User;

namespace SabayNew.Extention
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NewSbyContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SabayNewDbConnection")));
            services.AddTransient<NewSbyContext>();
            services.AddDistributedMemoryCache();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
