namespace ChurchManagement.Application.ViewModels.CargoVMs
{
    public class CargoViewModel
    {
        public CargoViewModel(int idCargo, int idDepartamento, string nome)
        {
            IdCargo = idCargo;
            IdDepartamento = idDepartamento;
            Nome = nome;
        }

        public CargoViewModel(int idCargo, int idDepartamento, string nome, string descricao, string funcao, int ativo)
        {
            IdCargo = idCargo;
            IdDepartamento = idDepartamento;
            Nome = nome;
            Descricao = descricao;
            Funcao = funcao;
            Ativo = ativo;
        }
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Funcao { get; set; }
        public int Ativo { get; set; }
    }
}