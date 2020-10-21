using System;
using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Entities;

namespace IronFit.Application.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<AdminForRegisterDto, User>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username.ToLower()));

            CreateMap<UserForRegisterDto, User>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username.ToLower()));

            CreateMap<UserForUpdateDto, User>();

            CreateMap<ModalidadeDto, Modalidade>();

            CreateMap<AlunoDto, Aluno>()
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.Date));

            CreateMap<PagamentoDto, Pagamento>();
        }
    }
}
