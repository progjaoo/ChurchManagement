using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.UpdateMember
{
    public class UpdateMembroCommandHandler : IRequestHandler<UpdateMembroCommand, Unit>
    {
        private readonly IMembroRepository _membroRepository;
        public UpdateMembroCommandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<Unit> Handle(UpdateMembroCommand request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByIdAsync(request.IdMembro);

            membro.UpdateMembro(request.IdCargo, request.NomeCompleto, request.DataNasc,
                request.Cargo, request.EstadoCivil, request.Endereco,
                request.Telefone, request.Email, request.DataBatismo);

            await _membroRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
