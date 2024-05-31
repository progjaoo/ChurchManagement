using MediatR;

namespace ChurchManagement.Application.Commands.Membros.GerarPDFCarteirinha
{
    public class GerarPDFCarteirinhaCommand : IRequest<byte[]>
    {
        public int IdMembro { get; set; }

        public GerarPDFCarteirinhaCommand(int idMembro)
        {
            IdMembro = idMembro;
        }
    }
}
