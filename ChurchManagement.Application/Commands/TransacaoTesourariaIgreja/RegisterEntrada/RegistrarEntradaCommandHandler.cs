using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Enums;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.TransacaoTesourariaIgreja.RegisterEntrada
{
    public class RegistrarEntradaCommandHandler : IRequestHandler<RegistrarEntradaCommand, int>
    {
        private readonly ITesourariaRepository _tesourariaRepository;
        private readonly ITransacaoTesourariaRepository _transacaoTesourariaRepository;

        public RegistrarEntradaCommandHandler(ITransacaoTesourariaRepository transacaoTesourariaRepository, ITesourariaRepository tesourariaRepository)
        {
            _transacaoTesourariaRepository = transacaoTesourariaRepository;
            _tesourariaRepository = tesourariaRepository;
        }

        public async Task<int> Handle(RegistrarEntradaCommand request, CancellationToken cancellationToken)
        {
            var tesouraria = await _tesourariaRepository.GetByIdAsync(request.IdTesouraria);
            if (tesouraria == null)
            {
                throw new Exception("Tesouraria não encontrada.");
            }

            var transacao = new TransacaoTesouraria(request.TipoTransacao, request.TipoEntrada, request.Quantidade, request.Descricao, request.IdTesouraria);
            await _transacaoTesourariaRepository.AddAsync(transacao);

            if (request.TipoTransacao == TipoTransacaoEnum.Depósito)
            {
                tesouraria.AdicionarValor(request.Quantidade);
            }
            else if (request.TipoTransacao == TipoTransacaoEnum.Saque)
            {
                tesouraria.RetirarValor(request.Quantidade);
            }

            await _tesourariaRepository.UpdateAsync(tesouraria);
            await _tesourariaRepository.SaveChangesAsync();

            return transacao.IdTesourariaTransacao;
        }
    }
}