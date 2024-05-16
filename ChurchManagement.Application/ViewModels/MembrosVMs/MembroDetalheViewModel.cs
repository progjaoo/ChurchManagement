using ChurchManagement.Core.Enums;
using MediatR;

namespace ChurchManagement.Application.ViewModels.MembrosVMs
{
    public class MembroDetalheViewModel
    {
        public MembroDetalheViewModel(int idMembro, int idCargo,
            string nomeCompleto, DateTime? dataNasc, CargoEnum cargo,
            EstadoCivilEnum estadoCivil, string endereco,
            string telefone,
            string email, DateTime? dataCadastro,
            DateTime? dataBatismo)
        {
            IdMembro = idMembro;
            IdCargo = idCargo;
            NomeCompleto = nomeCompleto;
            DataNasc = dataNasc;
            Cargo = cargo;
            EstadoCivil = estadoCivil;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            DataCadastro = dataCadastro;
            DataBatismo = dataBatismo;
        }

        public int IdMembro { get; set; }
        public int IdCargo { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNasc { get; set; }
        public CargoEnum Cargo { get; set; }
        public EstadoCivilEnum EstadoCivil { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataBatismo { get; set; }
    }
}
