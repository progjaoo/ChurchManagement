using MediatR;

namespace ChurchManagement.Application.Commands.Categorias.Create
{
    public class CreateCategoriaCommand : IRequest<int>
    {
        public CreateCategoriaCommand(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
