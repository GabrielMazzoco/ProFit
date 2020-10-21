using AutoMapper;
using IronFit.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace IronFit.Api.Configs
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoToDomainProfile());
                mc.AddProfile(new DomainToDtoProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
