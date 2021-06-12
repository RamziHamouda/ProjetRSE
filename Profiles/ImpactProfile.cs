using AutoMapper;
using RSEBack.Dtos;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class ImpactProfile : Profile {
        public ImpactProfile()
        {
            CreateMap<Impact, ImpactReadDto>();
            CreateMap<ImpactCreateDto, Impact>();
            CreateMap<ImpactUpdateDto, Impact>();
        }
    }
}