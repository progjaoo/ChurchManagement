using ChurchManagement.Application.Commands.Membros.CreateMember;
using ChurchManagement.Application.Commands.Tesouraria;
using ChurchManagement.Application.Commands.TransacaoTesourariaIgreja.RegisterEntrada;
using ChurchManagement.Application.Commands.TransacaoTesourariaIgreja.RegisterSaida;
using ChurchManagement.Application.Queries.TransacaoTesourariaIgreja.GetCaixaAsync;
using ChurchManagement.Core.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagement.API.Controllers
{
    [Route("api/tesouraria")]
    public class TesourariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TesourariaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCaixaAsync()
        {
            var caixaQuery = new GetCaixaQuery();

            if(caixaQuery == null)
            {
                return BadRequest();
            }

            var resultado = await _mediator.Send(caixaQuery);

            return Ok(resultado);
        }
        [HttpPost("Criar-Tesouraria")]
        public async Task<IActionResult> Post([FromBody] CreateTesourariaCommand command)
        {
            var idTesouraria = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCaixaAsync), new { id = idTesouraria }, command);
        }
        [HttpPost("RegistrarEntrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] RegistrarEntradaCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCaixaAsync), new { id = result }, command);
        }

        [HttpPost("RegistrarSaida")]
        public async Task<IActionResult> RegistrarSaida([FromBody] RegisterSaidaCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCaixaAsync), new { id = result }, command);
        }
    }
}
