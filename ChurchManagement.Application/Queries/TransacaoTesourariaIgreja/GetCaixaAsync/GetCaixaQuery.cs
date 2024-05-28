using ChurchManagement.Application.ViewModels;
using MediatR;

namespace ChurchManagement.Application.Queries.TransacaoTesourariaIgreja.GetCaixaAsync
{
    public class GetCaixaQuery : IRequest<CaixaViewModel> { }
}
