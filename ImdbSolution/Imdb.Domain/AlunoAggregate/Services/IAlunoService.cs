using System.Collections.Generic;
using IronFit.Domain.AlunoAggregate.Dtos;

namespace IronFit.Domain.AlunoAggregate.Services
{
    public interface IAlunoService
    {
        IEnumerable<AlunoDto> BuscarTodos();
        AlunoDto Buscar(int id);
        void Criar(AlunoDto alunoDto);
        void Atualizar(AlunoDto alunoDto);
        void Inativar(int id);
        void Reativar(int id);
    }
}
