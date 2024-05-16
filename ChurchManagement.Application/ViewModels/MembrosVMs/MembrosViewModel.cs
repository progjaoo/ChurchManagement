using ChurchManagement.Core.Enums;

namespace ChurchManagement.Application.ViewModels.MembrosVMs
{
    public class MembrosViewModel
    {
        public MembrosViewModel(int idMembro, string nomeCompleto, CargoEnum cargo)
        {
            IdMembro = idMembro;
            NomeCompleto = nomeCompleto;
            Cargo = cargo;
        }
        public int IdMembro { get; set; }
        public string NomeCompleto { get; set; }
        public CargoEnum Cargo { get; set; }
    }
}
