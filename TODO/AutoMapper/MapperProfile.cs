using TODO.Domain.Entities;
using AutoMapper;
using TODO.Domain.Models.Request;

namespace TODO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TodoAddRequest, Todo>();
            CreateMap<TodoUpdateRequest, Todo>();
        }
    }
}