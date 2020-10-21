using System;
using IronFit.Adapter.Data;
using IronFit.Adapter.Data.Repositories;
using IronFit.Adapter.Data.UoW;
using IronFit.Domain.AlunoAggregate.Repositories;
using IronFit.Domain.AuthAggregate.Repositories;
using IronFit.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IronFit.Adapter.DependencyInjection
{
    public static class ImdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddAdapter(this IServiceCollection services
            , IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<DataContext>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
