using AutoMapper;
using DTO_demo.DTO;
using DTO_demo.Models;

namespace DTO_demo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
