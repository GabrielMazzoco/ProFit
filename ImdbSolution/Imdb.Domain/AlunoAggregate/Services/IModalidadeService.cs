using System.Collections.Generic;
using IronFit.Domain.AlunoAggregate.Dtos;

namespace IronFit.Domain.AlunoAggregate.Services
{
    public interface IModalidadeService
    {
        IEnumerable<ModalidadeDto> BuscarTodos();
        ModalidadeDto Buscar(int id);
        void Criar(ModalidadeDto modalidadeDto);
        void Atualizar(ModalidadeDto modalidadeDto);
        void Inativar(int id);
    }
}
