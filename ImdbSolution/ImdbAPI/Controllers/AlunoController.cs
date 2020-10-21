using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronFit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var modalidades = _alunoService.BuscarTodos();

            return Ok(modalidades);
        }

        [HttpGet("{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            var modalidade = _alunoService.Buscar(id);

            return Ok(modalidade);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] AlunoDto alunoDto)
        {
            _alunoService.Criar(alunoDto);

            return Created("Modalidade", new { });
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] AlunoDto alunoDto)
        {
            _alunoService.Atualizar(alunoDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Inativar([FromRoute] int id)
        {
            _alunoService.Inativar(id);

            return Ok();
        }

        [HttpPost("reativar/{id}")]
        public IActionResult Reativar([FromRoute] int id)
        {
            _alunoService.Reativar(id);

            return Ok();
        }
    }
}
