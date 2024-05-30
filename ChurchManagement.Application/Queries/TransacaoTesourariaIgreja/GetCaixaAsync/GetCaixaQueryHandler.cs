using ChurchManagement.Application.ViewModels.TesourariaVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.TransacaoTesourariaIgreja.GetCaixaAsync
{
    public class GetCaixaQueryHandler : IRequestHandler<GetCaixaQuery, CaixaViewModel>
    {
        private readonly ITesourariaRepository _tesourariaRepository;
        public GetCaixaQueryHandler(ITesourariaRepository tesourariaRepository)
        {
            _tesourariaRepository = tesourariaRepository;
        }
        public async Task<CaixaViewModel> Handle(GetCaixaQuery request, CancellationToken cancellationToken)
        {
            var caixa = await _tesourariaRepository.GetCaixaAsync();

            if (caixa == null) return null;

            var caixaViewModel = new CaixaViewModel(
                caixa.IdTesouraria,
                caixa.CaixaFixo);

            return caixaViewModel;
        }
    }
}
