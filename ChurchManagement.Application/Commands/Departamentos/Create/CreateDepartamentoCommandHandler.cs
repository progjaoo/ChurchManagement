using ChurchManagement.Core.Entidades;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Create
{
    public class CreateDepartamentoCommandHandler : IRequestHandler<CreateDepartamentoCommand, int>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public CreateDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public async Task<int> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = new Departamento(request.Nome, request.Descricao, request.Lider);

            await _departamentoRepository.AddAsync(departamento);
            await _departamentoRepository.SaveChangesAsync();

            return departamento.IdDepartamento;
        }
    }
}
