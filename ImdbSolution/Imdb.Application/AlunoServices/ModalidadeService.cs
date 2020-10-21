﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using IronFit.Domain.AlunoAggregate.Services;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Application.AlunoServices
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _modalidadeRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public ModalidadeService(
            IModalidadeRepository modalidadeRepository, 
            IMapper mapper, 
            IUnityOfWork unityOfWork)
        {
            _modalidadeRepository = modalidadeRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public IEnumerable<ModalidadeDto> BuscarTodos()
        {
            var modalidades = _modalidadeRepository.GetAll().Where(x => x.Active);

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
    }
}
