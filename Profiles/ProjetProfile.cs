using AutoMapper;
using RSEBack.Dtos;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class ProjetProfile : Profile {
        public ProjetProfile()
        {
            CreateMap<Projet, ProjetReadDto>();
            CreateMap<ProjetCreateDto, Projet>();
            CreateMap<ProjetUpdateDto, Projet>();
        }
    }
}