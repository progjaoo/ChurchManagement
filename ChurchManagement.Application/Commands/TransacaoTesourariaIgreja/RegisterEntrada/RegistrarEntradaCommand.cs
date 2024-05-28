using ChurchManagement.Core.Enums;
using MediatR;

namespace ChurchManagement.Application.Commands.TransacaoTesourariaIgreja.RegisterEntrada
{
    public class RegistrarEntradaCommand : IRequest<int>
    {
        public int IdTesouraria { get; set; }
        public decimal Quantidade { get; set; }
        public string Descricao { get; set; }
        public TipoTransacaoEnum TipoTransacao { get; set; }
        public EntradaEnum TipoEntrada { get; set; }
    }
}
