using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManagement.Application.ViewModels.DepartamentosVMs
{
    public class DepartamentoDetalheViewModel
    {
        public DepartamentoDetalheViewModel(int idDepartamento, string nome, string descricao, string lider)
        {
            IdDepartamento = idDepartamento;
            Nome = nome;
            Descricao = descricao;
            Lider = lider;
        }
        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lider { get; set; }
    }
}
