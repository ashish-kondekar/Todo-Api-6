using TODO.BLL.Models.Request;
using TODO.Domain.Entities;
using AutoMapper;

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
