using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Update
{
    public class UpdateCargoCommandHandler : IRequestHandler<UpdateCargoCommand, Unit>
    {
        private readonly ICargoRepository _cargoRepository;
        public UpdateCargoCommandHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<Unit> Handle(UpdateCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.GetByIdAsync(request.IdCargo);

            cargo.Update(request.IdDepartamento, request.Nome, request.Descricao, request.Funcao, request.Ativo);

            await _cargoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
