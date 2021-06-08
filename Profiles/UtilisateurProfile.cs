using AutoMapper;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class UtilisateurProfile : Profile {
        public UtilisateurProfile()
        {
            CreateMap<Utilisateur, UtilisateurReadDto>();
            CreateMap<UtilisateurCreateDto, Utilisateur>();
            CreateMap<UtilisateurUpdateDto, Utilisateur>();
        }
    }
}