using AutoMapper;

namespace ProcessFlow.Models.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaModel>()
                .ReverseMap();
        }
    }
}
