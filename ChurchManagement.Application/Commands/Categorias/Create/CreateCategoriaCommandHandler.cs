using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Create
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, int>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CreateCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoriaDespesa(request.Nome);

            await _categoriaRepository.AddAsync(category);
            await _categoriaRepository.SaveChangesAsync();

            return category.IdCategoria;
        }
    }
}
