using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Delete
{
    public class DeleteCargoCommandHandler : IRequestHandler<DeleteCargoCommand, Unit>
    {
        private readonly ICargoRepository _cargoRepository;
        public DeleteCargoCommandHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<Unit> Handle(DeleteCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.GetByIdAsync(request.IdCargo);

            await _cargoRepository.DeleteAsync(cargo.IdCargo);

            await _cargoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
