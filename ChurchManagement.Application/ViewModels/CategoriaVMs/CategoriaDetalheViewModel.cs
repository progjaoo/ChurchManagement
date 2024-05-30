namespace ChurchManagement.Application.ViewModels.CategoriaVMs
{
    public class CategoriaDetalheViewModel
    {
        public CategoriaDetalheViewModel(int idCategoria, string nome)
        {
            IdCategoria = idCategoria;
            Nome = nome;
        }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
    }
}
