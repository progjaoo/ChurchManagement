namespace ChurchManagement.Application.ViewModels.DepartamentosVMs
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel(int idDepartamento, string nome)
        {
            IdDepartamento = idDepartamento;
            Nome = nome;
        }
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
    }
}
