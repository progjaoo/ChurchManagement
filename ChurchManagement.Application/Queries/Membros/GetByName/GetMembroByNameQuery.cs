using ChurchManagement.Application.ViewModels.MembrosVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByName
{
    public class GetMembroByNameQuery : IRequest<MembrosViewModel>
    {
        public GetMembroByNameQuery(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }
        public string NomeCompleto { get; set; }
    }
}
