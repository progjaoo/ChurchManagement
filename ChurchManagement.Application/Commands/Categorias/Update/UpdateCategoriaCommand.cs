using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Update
{
    public class UpdateCategoriaCommand : IRequest<Unit>
    {
        public UpdateCategoriaCommand(int idCategoria, string nome)
        {
            IdCategoria = idCategoria;
            Nome = nome;
        }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
    }
}
