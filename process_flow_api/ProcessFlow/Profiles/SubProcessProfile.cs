using AutoMapper;
using ProcessFlow.Models;

namespace ProcessFlow.Profiles
{
    public class SubProcessProfile : Profile
    {
        public SubProcessProfile()
        {
            CreateMap<SubProcess, SubProcessModel>()
                .ReverseMap();
        }
    }
}
