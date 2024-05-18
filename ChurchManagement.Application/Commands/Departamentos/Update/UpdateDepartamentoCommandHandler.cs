using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Departamentos.Update
{
    public class UpdateDepartamentoCommandHandler : IRequestHandler<UpdateDepartamentoCommand, Unit>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public UpdateDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public async Task<Unit> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(request.IdDepartamento);

            departamento.Update(request.Nome, request.Descricao, request.Lider);
            await _departamentoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
