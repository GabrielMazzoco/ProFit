using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProFit.Infra.Data;
using Microsoft.EntityFrameworkCore;
using ProFit.Core.Shared.Interfaces.UoW;
using ProFit.Infra.Data.UoW;

namespace ProFit.Cross
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            // Services
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<ILeilaoService, LeilaoService>();
            //services.AddScoped<IFotoService, FotoService>();
            //services.AddScoped<ILoteService, LoteService>();
            //services.AddScoped<ILanceService, LanceService>();

            // Repositories
            //services.AddScoped<IAuthRepository, AuthRepository>();
            //services.AddScoped<ILeilaoRepository, LeilaoRepository>();
            //services.AddScoped<IFotoRepository, FotoRepository>();
            //services.AddScoped<ILoteRepository, LoteRepository>();
            //services.AddScoped<ILanceRepository, LanceRepository>();

            services.AddScoped<DataContext>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
