using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/suggestion
    [Route("api/suggestion")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionRepo _repository;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public SuggestionController(ISuggestionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/suggestion 
        // retourner les suggestions d'un utilisateur particulier
        [HttpGet("{idUtilisateur}")]
        public ActionResult <IEnumerable<SuggestionReadDto>> GetAllSuggestions(int idUtilisateur)
        {
            var SuggestionItems = _repository.GetAllSuggestion(idUtilisateur);
            return  Ok(_mapper.Map<IEnumerable<SuggestionReadDto>>(SuggestionItems));
        }

        // Get api/suggestion/unique/id
        [HttpGet("unique/{idSuggestion}", Name ="GetSuggestionById")]
        public ActionResult <SuggestionReadDto> GetSuggestionById(int idSuggestion)
        {
            var SuggestionItem = _repository.GetSuggestionById(idSuggestion);
            if(SuggestionItem != null) return Ok(_mapper.Map<SuggestionReadDto>(SuggestionItem));
            else return NotFound();
        }

        // Post api/suggestion
        [HttpPost("{idUtilisateur}")]
        public ActionResult <Suggestion> CreateSuggestion(int idUtilisateur, Suggestion SuggestionCreateDto)
        {
            Suggestion SuggestionModel = _mapper.Map<Suggestion>(SuggestionCreateDto);
            _repository.CreateSuggestion(idUtilisateur, SuggestionModel);
            _repository.SaveChanges();
            SuggestionReadDto SuggestionReadDto = _mapper.Map<SuggestionReadDto>(SuggestionModel);
            return CreatedAtRoute(nameof(GetSuggestionById), new {idSuggestion = SuggestionReadDto.Id}, SuggestionReadDto);
        }

        // Delete api/suggestion/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSuggestion(int id){
            
            Suggestion SuggestionModel = _repository.GetSuggestionById(id);
            if(SuggestionModel == null){
                return NotFound();
            }
            _repository.DeleteSuggestion(SuggestionModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<SuggestionReadDto>(SuggestionModel));
        }
    }
}
