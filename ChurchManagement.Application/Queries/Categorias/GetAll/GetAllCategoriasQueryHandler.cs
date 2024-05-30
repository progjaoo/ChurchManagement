using ChurchManagement.Application.ViewModels.CategoriaVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Categorias.GetAll
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, List<CategoriaViewModel>>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public async Task<List<CategoriaViewModel>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoriaRepository.GetAllAsync();

            if (category == null) return null;

            var categoryViewModel = category.Select(c => new CategoriaViewModel(
                c.Nome)).ToList();

            return categoryViewModel;
        }
    }
}
