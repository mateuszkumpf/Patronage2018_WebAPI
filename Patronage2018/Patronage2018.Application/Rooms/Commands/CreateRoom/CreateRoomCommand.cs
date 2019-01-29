using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
