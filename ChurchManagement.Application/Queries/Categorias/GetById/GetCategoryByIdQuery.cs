using ChurchManagement.Application.ViewModels.CategoriaVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Categorias.GetById
{
    public class GetCategoryByIdQuery : IRequest<CategoriaDetalheViewModel>
    {
        public GetCategoryByIdQuery(int idCategoria)
        {
            IdCategoria = idCategoria;
        }
        public int IdCategoria { get; set; }
    }
}
