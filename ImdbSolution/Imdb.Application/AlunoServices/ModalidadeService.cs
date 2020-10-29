using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using IronFit.Domain.AlunoAggregate.Services;
using IronFit.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IronFit.Application.AlunoServices
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _modalidadeRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IHttpContextAccessor _httpContext;

        public ModalidadeService(
            IModalidadeRepository modalidadeRepository, 
            IMapper mapper, 
            IUnityOfWork unityOfWork, 
            IHttpContextAccessor httpContext)
        {
            _modalidadeRepository = modalidadeRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _httpContext = httpContext;
        }

        public IEnumerable<ModalidadeDto> BuscarTodos()
        {
            var idsAcademias = ObterIdsAcademias();

            var modalidades = _modalidadeRepository.GetAll()
                .Where(x => x.Active && idsAcademias.Contains(x.IdAcademia));

            return _mapper.Map<IEnumerable<ModalidadeDto>>(modalidades);
        }

        public ModalidadeDto Buscar(int id)
        {
            var modalidade = _modalidadeRepository.GetById(id);

            return _mapper.Map<ModalidadeDto>(modalidade);
        }

        public void Criar(ModalidadeDto modalidadeDto)
        {
            var modalidade = _mapper.Map<Modalidade>(modalidadeDto);

            _modalidadeRepository.Create(modalidade);

            _unityOfWork.Commit();
        }

        public void Atualizar(ModalidadeDto modalidadeDto)
        {
            var modalidade = _mapper.Map<Modalidade>(modalidadeDto);

            _modalidadeRepository.Update(modalidade);

            _unityOfWork.Commit();
        }

        public void Inativar(int id)
        {
            var modalidade = new Modalidade {Id = id, Active = false};

            _modalidadeRepository.Inactivate(modalidade);

            _unityOfWork.Commit();
        }

        private IEnumerable<int> ObterIdsAcademias()
        {
            var academias = _httpContext.HttpContext.User.FindFirst("Academias").Value;

            var idAcademias = academias.Split(",").Select(int.Parse);

            return idAcademias;
        }
    }
}
