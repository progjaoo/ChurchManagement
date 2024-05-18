using ChurchManagement.Application.ViewModels.DepartamentosVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Departamentos.GetAll
{
    public class GetAllDepartamentosQueryHandler : IRequestHandler<GetAllDepartamentosQuery, List<DepartamentoViewModel>>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public GetAllDepartamentosQueryHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public async Task<List<DepartamentoViewModel>> Handle(GetAllDepartamentosQuery request, CancellationToken cancellationToken)
        {
            var departamento = await _departamentoRepository.GetAllAsync();

            if (departamento == null) return null;

            var departamentoViewModel = departamento.Select(d => new DepartamentoViewModel(
                d.IdDepartamento,
                d.Nome)).ToList();

            return departamentoViewModel;
        }
    }
}
