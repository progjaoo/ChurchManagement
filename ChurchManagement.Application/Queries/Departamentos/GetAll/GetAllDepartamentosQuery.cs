using ChurchManagement.Application.ViewModels.DepartamentosVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Departamentos.GetAll
{
    public class GetAllDepartamentosQuery : IRequest<List<DepartamentoViewModel>> { }
}
