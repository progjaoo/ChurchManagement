using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Update
{
    public class UpdateDepartamentoCommand : IRequest<Unit>
    {
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lider { get; set; }
    }
}
