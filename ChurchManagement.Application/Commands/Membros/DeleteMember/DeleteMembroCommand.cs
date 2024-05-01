using MediatR;

namespace ChurchManagement.Application.Commands.Membros.DeleteMember
{
    public class DeleteMembroCommand : IRequest<Unit>
    {
        public DeleteMembroCommand(int idMembro)
        {
            IdMembro = idMembro;
        }
        public int IdMembro { get; set; }
    }
}
