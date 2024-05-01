using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.DeleteMember
{
    public class DeleteMembroCommandHandler : IRequestHandler<DeleteMembroCommand, Unit>
    {
        private readonly IMembroRepository _membroRepository;
        public DeleteMembroCommandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<Unit> Handle(DeleteMembroCommand request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByIdAsync(request.IdMembro);

            await _membroRepository.DeleteAsync(membro.IdMembro);
            await _membroRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
