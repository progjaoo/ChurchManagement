using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Create
{
    public class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, int>
    {
        private readonly ICargoRepository _cargoRepository;
        public CreateCargoCommandHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<int> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = new Cargo(request.IdDepartamento, request.Nome, request.Descricao, request.Funcao, request.Ativo);

            await _cargoRepository.AddAsync(cargo);
            await _cargoRepository.SaveChangesAsync();

            return cargo.IdCargo;
        }
    }
}
