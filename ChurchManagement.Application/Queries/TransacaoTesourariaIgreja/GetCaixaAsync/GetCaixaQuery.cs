using ChurchManagement.Application.ViewModels.TesourariaVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.TransacaoTesourariaIgreja.GetCaixaAsync
{
    public class GetCaixaQuery : IRequest<CaixaViewModel> { }
}
