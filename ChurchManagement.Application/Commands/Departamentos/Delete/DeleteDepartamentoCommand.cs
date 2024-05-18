using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Delete
{
    public class DeleteDepartamentoCommand : IRequest<Unit>
    {
        public DeleteDepartamentoCommand(int idDepartamento)
        {
            IdDepartamento = idDepartamento;
        }
        public int IdDepartamento { get; set; } 
    }
}
