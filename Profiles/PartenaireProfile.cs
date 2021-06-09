using AutoMapper;
using RSEBack.Dtos;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class PartenaireProfile : Profile {
        public PartenaireProfile()
        {
            CreateMap<Partenaire, PartenaireReadDto>();
            CreateMap<PartenaireCreateDto, Partenaire>();
            CreateMap<PartenaireUpdateDto, Partenaire>();
        }
    }
}