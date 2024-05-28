using MediatR;

namespace ChurchManagement.Application.Commands.Tesouraria
{
    public class CreateTesourariaCommand : IRequest<int>
    {
        public decimal? CaixaFixo { get; set; }
    }
}
