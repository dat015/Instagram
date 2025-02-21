using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using server.Database_SQL;
using server.Services.AuthService;
using server.Services.UserSV;

namespace server.InjectService
{
    public static class DJ
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenApi();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAuthService, AuthService>();
        }

    }
}
