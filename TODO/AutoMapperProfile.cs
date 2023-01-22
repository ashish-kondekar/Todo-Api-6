using TODO.BLL.Models.Request;
using TODO.Domain.Entities;
using AutoMapper;

namespace TODO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoAddRequest, Todo>();
            CreateMap<TodoUpdateRequest, Todo>();
        }
    }
}
