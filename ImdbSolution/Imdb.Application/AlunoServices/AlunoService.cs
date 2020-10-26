using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using IronFit.Domain.AlunoAggregate.Services;
using IronFit.Domain.Shared.Exceptions;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Application.AlunoServices
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public AlunoService(
            IAlunoRepository alunoRepository, 
            IMapper mapper, 
            IUnityOfWork unityOfWork)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public IEnumerable<AlunoDto> BuscarTodos()
        {
            var alunos = _alunoRepository.GetAll().Where(x => x.Active);

            return _mapper.Map<IEnumerable<AlunoDto>>(alunos);
        }

        public IEnumerable<AlunoForGetDto> BuscarTodosPorNome(string nome)
        {
            var alunos = _alunoRepository.GetAlunos(nome);

            return alunos;
        }

        public AlunoDto Buscar(int id)
        {
            var aluno = _alunoRepository.GetById(id);

            return _mapper.Map<AlunoDto>(aluno);
        }

        public void Criar(AlunoDto alunoDto)
        {
            var alunoDb = _alunoRepository.AlunoExiste(alunoDto);

            if (alunoDb != null)
            {
                var exception = alunoDb.Active
                    ? new CoreException("Aluno já existe e está ativo.")
                    : new CoreException("Aluno já existe porém está inativo, você deve reativá-lo.");

                throw exception;
            }

            var aluno = _mapper.Map<Aluno>(alunoDto);

            aluno.DataMatricula = DateTime.Now;

            _alunoRepository.Create(aluno);

            _unityOfWork.Commit();
        }

        public void Atualizar(AlunoDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);

            _alunoRepository.Update(aluno);

            _unityOfWork.Commit();
        }

        public void Inativar(int id)
        {
            var aluno = new Aluno {Id = id, Active = false};

            _alunoRepository.Inactivate(aluno);

            _unityOfWork.Commit();
        }

        public void Reativar(int id)
        {
            var aluno = new Aluno { Id = id, Active = true };

            _alunoRepository.Inactivate(aluno);

            _unityOfWork.Commit();
        }
    }
}
