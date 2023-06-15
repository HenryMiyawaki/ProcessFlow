using AutoMapper;
using ProcessFlow.Models;

namespace ProcessFlow.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerModel>()
                .ReverseMap();
        }
    }
}
