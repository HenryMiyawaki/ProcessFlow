using AutoMapper;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Profiles
{
    public class ProcessProfile : Profile
    {
        public ProcessProfile()
        {
            CreateMap<ProcessDto, ProcessModel>()
                .ReverseMap();
        }
    }
}
