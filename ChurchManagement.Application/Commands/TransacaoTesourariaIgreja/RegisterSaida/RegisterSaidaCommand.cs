using ChurchManagement.Core.Enums;
using MediatR;

namespace ChurchManagement.Application.Commands.TransacaoTesourariaIgreja.RegisterSaida
{
    public class RegisterSaidaCommand : IRequest<int>
    {
        public decimal Quantidade { get; set; }
        public string Descricao { get; set; }
        public TipoTransacaoEnum TipoTransacao { get; set; }
        public TipoSaidaEnum TipoSaida { get; set; }
        public int IdTesouraria { get; set; }
    }
}
