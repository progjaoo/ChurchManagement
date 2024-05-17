using ChurchManagement.Application.Commands.Cargos.Create;
using ChurchManagement.Application.Commands.Cargos.Delete;
using ChurchManagement.Application.Commands.Cargos.Update;
using ChurchManagement.Application.Queries.Cargos.GetAll;
using ChurchManagement.Application.Queries.Cargos.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagement.API.Controllers
{
    [ApiController]
    [Route("api/cargos")]
    public class CargoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CargoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Buscar-Todos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllCargosQuery();

            if (query == null)
                return NotFound();

            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
        [HttpGet("{id}/buscar-peloID")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var queryId = new GetCargoByIdQuery(id);

            if (queryId == null) return NotFound();

            var resultado = await _mediator.Send(queryId);

            return Ok(resultado);
        }
        [HttpPost("Criar-Cargo")]
        public async Task<IActionResult> Post([FromBody] CreateCargoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, command);
        }
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Put(UpdateCargoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCargoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
