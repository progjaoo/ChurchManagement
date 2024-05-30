using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public DeleteCategoryCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriaRepository.GetByIdAsync(request.IdCategoria);

            await _categoriaRepository.DeleteAsync(category.IdCategoria);
            await _categoriaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
