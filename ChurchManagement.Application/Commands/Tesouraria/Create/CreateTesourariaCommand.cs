using MediatR;

namespace ChurchManagement.Application.Commands.Tesouraria.Create
{
    public class CreateTesourariaCommand : IRequest<int>
    {
        public decimal? CaixaFixo { get; set; }
    }
}
