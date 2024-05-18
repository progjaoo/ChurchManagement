using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Delete
{
    public class DeleteDepartamentoCommandHandler : IRequestHandler<DeleteDepartamentoCommand, Unit>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DeleteDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public async Task<Unit> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(request.IdDepartamento);

            await _departamentoRepository.DeleteAsync(departamento.IdDepartamento);
            await _departamentoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
