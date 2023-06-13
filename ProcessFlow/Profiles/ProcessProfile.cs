using AutoMapper;
using ProcessFlow.Models;

namespace ProcessFlow.Profiles
{
    public class ProcessProfile : Profile
    {
        public ProcessProfile()
        {
            CreateMap<Process, ProcessModel>()
                .ReverseMap();
        }
    }
}
