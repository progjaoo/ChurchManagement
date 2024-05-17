using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Delete
{
    public class DeleteCargoCommand : IRequest<Unit>
    {
        public DeleteCargoCommand(int idCargo)
        {
            IdCargo = idCargo;
        }
        public int IdCargo { get; set; }
    }
}
