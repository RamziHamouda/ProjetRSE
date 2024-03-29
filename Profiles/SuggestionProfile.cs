using AutoMapper;
using RSEBack.Dtos;
using RSEBack.Models;

namespace rseback.profiles{

    // class to add configuration for maps
    public class SuggestionProfile : Profile {
        public SuggestionProfile()
        {
            CreateMap<Suggestion, SuggestionReadDto>();
            CreateMap<SuggestionCreateDto, Suggestion>();
        }
    }
}