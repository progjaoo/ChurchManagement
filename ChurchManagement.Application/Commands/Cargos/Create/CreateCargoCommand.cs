using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Create
{
    public class CreateCargoCommand : IRequest<int>
    {
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Funcao { get; set; }
        public int Ativo { get; set; }
    }
}
