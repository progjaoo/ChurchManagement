using ChurchManagement.Application.ViewModels;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByCargo
{
    public class GetMembroByCargoQuery : IRequest<MembrosViewModel>
    {
        public GetMembroByCargoQuery(int idCargo)
        {
            IdCargo = idCargo;
        }
        public int IdCargo { get; set; }
    }
}
