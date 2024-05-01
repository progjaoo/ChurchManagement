using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.CreateMember
{
    public class CreateMembroCommandHandler : IRequestHandler<CreateMembroCommand, int>
    {
        private readonly IMembroRepository _membroRepository;
        public CreateMembroCommandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<int> Handle(CreateMembroCommand request, CancellationToken cancellationToken)
        {
            var membro = new Membro(request.IdCargo, request.NomeCompleto, request.DataNasc,
                request.ImagemMembro, request.Cargo, request.EstadoCivil, request.Endereco, 
                request.Telefone, request.Email, request.DataBatismo);

            await _membroRepository.AddAsync(membro);
            await _membroRepository.SaveChangesAsync();

            return membro.IdMembro;
        }
    }
}