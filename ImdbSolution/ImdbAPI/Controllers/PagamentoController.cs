using IronFit.Domain.AlunoAggregate.Dtos;
using IronFit.Domain.AlunoAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronFit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public IActionResult RealizarPagamento([FromBody] PagamentoDto pagamentoDto)
        {
            _pagamentoService.RealizarPagamento(pagamentoDto);

            return Created("Pagamentos", new { });
        }

        [HttpGet("{aluno}")]
        public IActionResult BuscarPagamentos([FromRoute] string aluno)
        {
            var result = _pagamentoService.GetPagamentos(aluno);

            return Ok(result);
        }
    }
}
