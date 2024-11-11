using AutoMapper;

using FastX_Ticket_Booking_System.DTO;
using FastX_Ticket_Booking_System.Models;

namespace FastX_Ticket_Booking_System.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<bus, BusDTO>().ReverseMap();
        }
    }
}