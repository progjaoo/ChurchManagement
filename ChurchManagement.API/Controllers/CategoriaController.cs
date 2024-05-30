using ChurchManagement.Application.Commands.Categorias.Create;
using ChurchManagement.Application.Commands.Categorias.Delete;
using ChurchManagement.Application.Commands.Categorias.Update;
using ChurchManagement.Application.Queries.Categorias.GetAll;
using ChurchManagement.Application.Queries.Categorias.GetById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagement.API.Controllers
{

    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllCategoriasQuery();

            if (query == null)
                return NotFound();

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryId = new GetCategoryByIdQuery(id);

            if (queryId == null)
                return NotFound();

            var result = _mediator.Send(queryId);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoriaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateCategoriaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
