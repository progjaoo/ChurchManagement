using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManagement.Application.ViewModels
{
    public class CaixaViewModel
    {
        public CaixaViewModel(int idTesouraria, decimal? caixaFixo)
        {
            IdTesouraria = idTesouraria;
            CaixaFixo = caixaFixo;
        }

        public int IdTesouraria { get; set; } = 1;
        public decimal? CaixaFixo { get; set; }
    }
}
