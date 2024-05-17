using ChurchManagement.Application.ViewModels.CargoVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Cargos.GetAll
{
    public class GetAllCargosQueryHandler : IRequestHandler<GetAllCargosQuery, List<CargoViewModel>>
    {
        private readonly ICargoRepository _cargoRepository;
        public GetAllCargosQueryHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<List<CargoViewModel>> Handle(GetAllCargosQuery request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.GetAllAsync();

            if (cargo == null) return null;

            var cargoViewModel = cargo.Select(c => new CargoViewModel(
                c.IdCargo,
                c.IdDepartamento,
                c.Nome)).ToList();

            return cargoViewModel;
        }
    }
}
