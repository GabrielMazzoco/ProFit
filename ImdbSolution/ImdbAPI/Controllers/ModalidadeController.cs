using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronFit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ModalidadeController : ControllerBase
    {
        private readonly IModalidadeService _modalidadeService;

        public ModalidadeController(IModalidadeService modalidadeService)
        {
            _modalidadeService = modalidadeService;
        }

        [HttpGet]
        public IActionResult BuscarModalidades()
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            var modalidades = _modalidadeService.BuscarTodos();

            return Ok(modalidades);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarModalidade([FromRoute] int id)
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            var modalidade = _modalidadeService.Buscar(id);

            return Ok(modalidade);
        }

        [HttpPost]
        public IActionResult CriarModalidade([FromBody] ModalidadeDto modalidadeDto)
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            _modalidadeService.Criar(modalidadeDto);

            return Created("Modalidade", new { });
        }

        [HttpPut]
        public IActionResult AtualizarModalidade([FromBody] ModalidadeDto modalidadeDto)
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            _modalidadeService.Atualizar(modalidadeDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult InativarModalidade([FromRoute] int id)
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            _modalidadeService.Inativar(id);

            return Ok();
        }

        private bool VerificarAdmin()
        {
            var admin = bool.Parse(User.FindFirst("Admin").Value);

            return admin;
        }
    }
}
