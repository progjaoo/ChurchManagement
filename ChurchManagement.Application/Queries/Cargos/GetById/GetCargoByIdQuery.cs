using ChurchManagement.Application.ViewModels.CargoVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Cargos.GetById
{
    public class GetCargoByIdQuery : IRequest<CargoViewModel>
    {
        public GetCargoByIdQuery(int idCargo)
        {
            IdCargo = idCargo;
        }
        public int IdCargo {  get; set; }
    }
}
