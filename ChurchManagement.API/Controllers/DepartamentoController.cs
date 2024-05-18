using ChurchManagement.Application.Commands.Departamentos.Create;
using ChurchManagement.Application.Commands.Departamentos.Delete;
using ChurchManagement.Application.Commands.Departamentos.Update;
using ChurchManagement.Application.Queries.Departamentos.GetAll;
using ChurchManagement.Application.Queries.Departamentos.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagement.API.Controllers
{
    [Route("api/departamentos")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Buscar-Todos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllDepartamentosQuery();

            if (query == null)
                return NotFound();

            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
        [HttpGet("{id}/buscar-peloID")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var queryId = new GetDepartamentoByIdQuery(id);

            if (queryId == null) return NotFound();

            var resultado = await _mediator.Send(queryId);

            return Ok(resultado);
        }
        [HttpPost("criar-Departamento")]
        public async Task<IActionResult> Post([FromBody] CreateDepartamentoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateDepartamentoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteDepartamentoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
