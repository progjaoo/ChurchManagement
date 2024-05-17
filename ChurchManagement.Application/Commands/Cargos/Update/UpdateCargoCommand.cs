using MediatR;

namespace ChurchManagement.Application.Commands.Cargos.Update
{
    public class UpdateCargoCommand : IRequest<Unit>
    {
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Funcao { get; set; }
        public int Ativo { get; set; }
    }
}
