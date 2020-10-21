using System;
using IronFit.Application.AlunoServices;
using IronFit.Application.AuthServices;
using IronFit.Domain.AlunoAggregate.Services;
using IronFit.Domain.AuthAggregate.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IronFit.Application.DependencyInjection
{
    public static class ImdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IModalidadeService, ModalidadeService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IPagamentoService, PagamentoService>();

            return services;
        }
    }
}
