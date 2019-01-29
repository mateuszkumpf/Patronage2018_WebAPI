using AutoMapper;
using Patronage2018.Application.Interfaces.Mapping;
using Patronage2018.Domain.Entities;

namespace Patronage2018.Application.Rooms.Queries.GetAllRooms
{
    public class RoomLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Room, RoomLookupModel>()
                .ForMember(rDto => rDto.Id, opt => opt.MapFrom(c => c.RoomId))
                .ForMember(rDto => rDto.Name, opt => opt.MapFrom(c => c.RoomName));
        }
    }
}