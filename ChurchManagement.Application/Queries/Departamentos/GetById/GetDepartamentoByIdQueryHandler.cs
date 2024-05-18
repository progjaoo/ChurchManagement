using ChurchManagement.Application.ViewModels.DepartamentosVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Departamentos.GetById
{
    public class GetDepartamentoByIdQueryHandler : IRequestHandler<GetDepartamentoByIdQuery, DepartamentoDetalheViewModel>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public GetDepartamentoByIdQueryHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public async Task<DepartamentoDetalheViewModel> Handle(GetDepartamentoByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departamentoRepository.GetByIdAsync(request.IdDepartamento);

            if (department == null) return null;

            var departamentoViewModel = new DepartamentoDetalheViewModel(
                department.IdDepartamento,
                department.Nome,
                department.Descricao,
                department.Lider);

            return departamentoViewModel;
        }
    }
}