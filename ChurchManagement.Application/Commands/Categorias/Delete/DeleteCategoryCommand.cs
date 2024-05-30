using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Delete
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public DeleteCategoryCommand(int idCategoria)
        {
            IdCategoria = idCategoria;
        }
        public int IdCategoria { get; set; }
    }
}
