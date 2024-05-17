using ChurchManagement.Application.ViewModels.CargoVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Cargos.GetAll
{
    public class GetAllCargosQuery : IRequest<List<CargoViewModel>> { }
}
