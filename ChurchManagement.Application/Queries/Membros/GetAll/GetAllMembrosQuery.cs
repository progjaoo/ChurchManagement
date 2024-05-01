﻿using ChurchManagement.Application.ViewModels;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetAll
{
    public class GetAllMembrosQuery : IRequest<List<MembrosViewModel>> { }
}
