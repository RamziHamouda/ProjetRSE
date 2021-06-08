using AutoMapper;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class ActualiteProfile : Profile {
        public ActualiteProfile()
        {
            CreateMap<Actualite, ActualiteReadDto>();
            CreateMap<ActualiteCreateDto, Actualite>();
            CreateMap<ActualiteUpdateDto, Actualite>();
        }
    }
}