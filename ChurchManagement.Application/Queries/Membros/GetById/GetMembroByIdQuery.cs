using ChurchManagement.Application.ViewModels.MembrosVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetById
{
    public class GetMembroByIdQuery : IRequest<MembroDetalheViewModel> 
    {
        public GetMembroByIdQuery(int idMembro)
        {
            IdMembro = idMembro;
        }
        public int IdMembro { get; set; }
    }
}
