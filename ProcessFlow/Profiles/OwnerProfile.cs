using AutoMapper;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerDto, OwnerModel>()
                .ReverseMap();
        }
    }
}
