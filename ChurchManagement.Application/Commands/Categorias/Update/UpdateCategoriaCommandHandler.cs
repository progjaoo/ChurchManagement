using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Update
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public UpdateCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriaRepository.GetByIdAsync(request.IdCategoria);

            category.Update(request.IdCategoria, request.Nome);
            await _categoriaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}