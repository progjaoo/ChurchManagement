using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Tesouraria.Create
{
    public class CreateTesourariaCommandHandler : IRequestHandler<CreateTesourariaCommand, int>
    {
        private readonly ITesourariaRepository _tesourariaRepository;
        public CreateTesourariaCommandHandler(ITesourariaRepository tesourariaRepository)
        {
            _tesourariaRepository = tesourariaRepository;
        }
        public async Task<int> Handle(CreateTesourariaCommand request, CancellationToken cancellationToken)
        {
            var tesouraria = new Core.Entidades.Tesouraria(request.CaixaFixo);

            await _tesourariaRepository.AddAsync(tesouraria);
            await _tesourariaRepository.SaveChangesAsync();

            return tesouraria.IdTesouraria;
        }
    }
}
