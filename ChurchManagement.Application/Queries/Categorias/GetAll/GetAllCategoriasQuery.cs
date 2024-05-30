using ChurchManagement.Application.ViewModels.CategoriaVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Categorias.GetAll
{
    public class GetAllCategoriasQuery : IRequest<List<CategoriaViewModel>> { }
}
