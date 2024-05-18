using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Create
{
    public class CreateDepartamentoCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lider { get; set; }
    }
}
