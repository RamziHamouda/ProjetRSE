using AutoMapper;
using RSEBack.Dtos;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class UtilisateurProfile : Profile {
        public UtilisateurProfile()
        {
            CreateMap<Utilisateur, UtilisateurReadDto>();
            CreateMap<Utilisateur, UtilisateurEquipeRSEReadDto>();
        }
    }
}