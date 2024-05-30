using ChurchManagement.Application.ViewModels.CategoriaVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Categorias.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoriaDetalheViewModel>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GetCategoryByIdQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<CategoriaDetalheViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoriaRepository.GetByIdAsync(request.IdCategoria);

            var categoryViewModel = new CategoriaDetalheViewModel
                (category.IdCategoria,
                category.Nome);

            return categoryViewModel;
        }
    }
}
