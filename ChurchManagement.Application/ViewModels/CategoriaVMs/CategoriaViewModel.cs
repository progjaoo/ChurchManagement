namespace ChurchManagement.Application.ViewModels.CategoriaVMs
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
