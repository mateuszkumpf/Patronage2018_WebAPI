using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Rooms.Queries.GetAllRooms
{
    public class GetAllRoomsQuery : IRequest<RoomsListViewModel>
    {
    }
}
