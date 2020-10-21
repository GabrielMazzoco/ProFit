using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;

namespace IronFit.Application.AutoMapper
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Modalidade, ModalidadeDto>();

            CreateMap<Aluno, AlunoDto>();
        }
    }
}
