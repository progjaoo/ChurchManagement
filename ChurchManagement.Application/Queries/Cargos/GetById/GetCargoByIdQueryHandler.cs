using ChurchManagement.Application.ViewModels.CargoVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Cargos.GetById
{
    public class GetCargoByIdQueryHandler : IRequestHandler<GetCargoByIdQuery, CargoViewModel>
    {
        private readonly ICargoRepository _cargoRepository;
        public GetCargoByIdQueryHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<CargoViewModel> Handle(GetCargoByIdQuery request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.GetByIdAsync(request.IdCargo);

            if (cargo == null) return null;

            var cargoViewModel = new CargoViewModel(cargo.IdCargo, cargo.IdDepartamento, 
                cargo.Nome, cargo.Descricao, cargo.Funcao, cargo.Ativo);

            return cargoViewModel;
        }
    }
}
