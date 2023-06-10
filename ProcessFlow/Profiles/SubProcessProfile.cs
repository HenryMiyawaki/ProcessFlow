using AutoMapper;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Profiles
{
    public class SubProcessProfile : Profile
    {
        public SubProcessProfile()
        {
            CreateMap<SubProcessDto, SubProcessModel>()
                .ReverseMap();
        }
    }
}
