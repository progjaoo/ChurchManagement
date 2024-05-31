using ChurchManagement.Application.Commands.Membros.CreateMember;
using ChurchManagement.Application.Commands.Membros.DeleteMember;
using ChurchManagement.Application.Commands.Membros.GerarPDFCarteirinha;
using ChurchManagement.Application.Commands.Membros.UpdateMember;
using ChurchManagement.Application.Commands.Membros.UploadImagem;
using ChurchManagement.Application.Queries.Membros.GetAll;
using ChurchManagement.Application.Queries.Membros.GetByCargo;
using ChurchManagement.Application.Queries.Membros.GetById;
using ChurchManagement.Application.Queries.Membros.GetByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagement.API.Controllers
{
    [ApiController]
    [Route("api/membros")]
    public class MembroController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var membroQuery = new GetAllMembrosQuery(); 

            if(membroQuery == null) return NotFound();
            
            var membros = await _mediator.Send(membroQuery);

            return Ok(membros);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var queryId = new GetMembroByIdQuery(id);

            if(queryId == null) return NotFound();

            var membros = await _mediator.Send(queryId);

            return Ok(membros);
        }
        [HttpGet("Buscar-pelo-Cargo")] //deixei sem o id aq para testar
        public async Task<IActionResult> GetByCargo(int cargoId)
        {
            var cargoQueryId = new GetMembroByCargoQuery(cargoId);

            if (cargoQueryId == null) return NotFound();

            var cargo = await _mediator.Send(cargoQueryId);

            return Ok(cargo);
        }
        [HttpGet("Buscar-pelo-Nome")]
        public async Task<IActionResult> GetByName(string name)
        {
            var namequery = new GetMembroByNameQuery(name);

            if (namequery == null) return NotFound();

            var nomes = await _mediator.Send(namequery);

            return Ok(nomes);
        }
        [HttpPost("Criar-Membros")]
        public async Task<IActionResult> Post([FromBody] CreateMembroCommand command)
        {
            var idMembro = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = idMembro }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateMembroCommand commmand)
        {
            await _mediator.Send(commmand);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteMembroCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("Enviar-Imagem")]
        public async Task<IActionResult> UploadImagem([FromForm] UploadImagemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result) return NotFound();

            return Created("Imagem foi enviada com sucesso", command.ImagemMembro.FileName);
        }
        [HttpGet("GerarPDFCarteirinha/{idMembro}")]
        public async Task<IActionResult> GerarPDFCarteirinha(int idMembro)
        {
            var result = await _mediator.Send(new GerarPDFCarteirinhaCommand(idMembro));
            return File(result, "application/pdf", "CarteirinhaMembro.pdf");
        }
    }
}
