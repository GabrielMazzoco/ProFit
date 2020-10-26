using System;
using AutoMapper;
using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Entidades;
using IronFit.Domain.AlunoAggregate.Repositories;
using IronFit.Domain.AlunoAggregate.Services;
using IronFit.Domain.Shared.Exceptions;
using IronFit.Domain.Shared.Interfaces;

namespace IronFit.Application.AlunoServices
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public PagamentoService(
            IPagamentoRepository pagamentoRepository, 
            IMapper mapper, 
            IUnityOfWork unityOfWork, 
            IAlunoRepository alunoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _alunoRepository = alunoRepository;
        }

        public void RealizarPagamento(PagamentoDto pagamentoDto)
        {
            var aluno = _alunoRepository.GetById(pagamentoDto.IdAluno);

            if (aluno is null) throw new CoreException("Aluno não encontrado para realizar Pagamento.");

            var pagamento = _mapper.Map<Pagamento>(pagamentoDto);

            if (pagamentoDto.MesInteiro)
            {
                pagamento.QuantidadeDias = DateTime.DaysInMonth(pagamentoDto.AnoReferencia, pagamentoDto.MesReferencia);
            }

            pagamento.DataPagamento = DateTime.Now;

            _pagamentoRepository.Create(pagamento);

            _unityOfWork.Commit();
        }
    }
}
