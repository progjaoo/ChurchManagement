using ChurchManagement.Core.Enums;

namespace ChurchManagement.Application.ViewModels
{
    public class MembrosViewModel 
    {
        public MembrosViewModel(int idMembro, string nomeCompleto, byte[] imagemMembro)
        {
            IdMembro = idMembro;
            NomeCompleto = nomeCompleto;
            ImagemMembro = imagemMembro;
        }
        public int IdMembro { get; set; }
        public string NomeCompleto { get; set; }
        public byte[] ImagemMembro { get; set; }

        public MembrosViewModel(CargoEnum cargo, int idCargo, string nomeCompleto)
        {
            Cargo = cargo;
            IdCargo = idCargo;
            NomeCompleto = nomeCompleto;
        }
        public int IdCargo { get; set; }
        public CargoEnum Cargo { get; set; }
    }
}
