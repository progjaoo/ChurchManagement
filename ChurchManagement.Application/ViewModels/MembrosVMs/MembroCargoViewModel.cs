namespace ChurchManagement.Application.ViewModels.MembrosVMs
{
    public class MembroCargoViewModel
    {
        public MembroCargoViewModel(int idCargo, string nomeCompleto)
        {
            IdCargo = idCargo;
            NomeCompleto = nomeCompleto;
        }
        public int IdCargo { get; set; }
        public string NomeCompleto { get; set; }
    }
}
