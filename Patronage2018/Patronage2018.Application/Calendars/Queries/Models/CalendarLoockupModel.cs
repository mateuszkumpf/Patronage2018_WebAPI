using AutoMapper;
using Patronage2018.Application.Interfaces.Mapping;
using Patronage2018.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage2018.Application.Calendars.Queries.Models
{
    public class CalendarLoockupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        
        public string RoomName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }


        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Calendar, CalendarLoockupModel>()
                         .ForMember(cDto => cDto.Id, opt => opt.MapFrom(c => c.CalendarId))
                         .ForMember(cDto => cDto.RoomName, opt => opt.MapFrom(c => c.Room != null ? c.Room.RoomName : string.Empty))
                         .ForMember(cDto => cDto.From, opt => opt.MapFrom(c => c.From))
                         .ForMember(cDto => cDto.To, opt => opt.MapFrom(c => c.To));
        }
    }
}
