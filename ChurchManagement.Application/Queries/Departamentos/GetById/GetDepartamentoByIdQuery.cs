using ChurchManagement.Application.ViewModels.DepartamentosVMs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManagement.Application.Queries.Departamentos.GetById
{
    public class GetDepartamentoByIdQuery : IRequest<DepartamentoDetalheViewModel>
    {
        public GetDepartamentoByIdQuery(int idDepartamento)
        {
            IdDepartamento = idDepartamento;
        }
        public int IdDepartamento {  get; set; }
    }
}
