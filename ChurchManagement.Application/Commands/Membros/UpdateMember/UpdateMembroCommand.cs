using ChurchManagement.Core.Enums;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.UpdateMember
{
    public class UpdateMembroCommand : IRequest<Unit>
    {
        public int IdMembro { get; set; }
        public int IdCargo { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNasc { get; set; }
        public CargoEnum Cargo { get; set; }
        public EstadoCivilEnum EstadoCivil { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime? DataBatismo { get; set; }
    }
}
