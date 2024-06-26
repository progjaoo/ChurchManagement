﻿using ChurchManagement.Application.ViewModels.MembrosVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByCargo
{
    public class GetMembroByCargoQuery : IRequest<MembroCargoViewModel>
    {
        public GetMembroByCargoQuery(int idCargo)
        {
            IdCargo = idCargo;
        }
        public int IdCargo { get; set; }
    }
}
