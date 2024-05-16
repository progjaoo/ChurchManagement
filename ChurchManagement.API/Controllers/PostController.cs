using ChurchManagement.Application.Commands.Membros.UploadImagem;
using ChurchManagement.Application.Commands.Posts.Create;
using ChurchManagement.Application.Commands.Posts.Delete;
using ChurchManagement.Application.Commands.Posts.Update;
using ChurchManagement.Application.Commands.Posts.UploadImagem;
using ChurchManagement.Application.Queries.Posts.GetAll;
using ChurchManagement.Application.Queries.Posts.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ChurchManagement.API.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Buscar-Todos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllPostQuery();

            if (query == null)
                return NotFound();

            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
        [HttpGet("{id}/buscar-peloID")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var queryId = new GetPostByIdQuery(id);

            if (queryId == null) return NotFound();

            var resultado = await _mediator.Send(queryId);

            return Ok(resultado);
        }
        [HttpPost("Criar-Post")]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new {id = id}, command);
        }
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Put(UpdatePostCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePostCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("Enviar-Imagem")]
        public async Task<IActionResult> UploadImagem([FromForm] UploadImagemPostCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result) return NotFound();

            return Created("Imagem enviada com sucesso!", command.Imagem.FileName);
        }
    }
}
