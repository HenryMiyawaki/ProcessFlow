using AutoMapper;
using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Models.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaDto, AreaModel>()
                .ReverseMap();
        }
    }
}
