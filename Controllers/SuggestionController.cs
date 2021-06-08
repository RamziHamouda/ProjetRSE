using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;

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
        [HttpGet]
        public ActionResult <IEnumerable<SuggestionReadDto>> GetAllSuggestions()
        {
            var SuggestionItems = _repository.GetAllSuggestion();
            return  Ok(_mapper.Map<IEnumerable<SuggestionReadDto>>(SuggestionItems));
        }

        // Get api/suggestion/{id}
        [HttpGet("{id}", Name ="GetSuggestionById")]
        public ActionResult <SuggestionReadDto> GetSuggestionById(int id)
        {
            var SuggestionItem = _repository.GetSuggestionById(id);
            if(SuggestionItem != null) return Ok(_mapper.Map<SuggestionReadDto>(SuggestionItem));
            else return NotFound();
        }

        // Post api/suggestion
        [HttpPost]
        public ActionResult <Suggestion> CreateSuggestion(Suggestion SuggestionCreateDto)
        {
            Suggestion SuggestionModel = _mapper.Map<Suggestion>(SuggestionCreateDto);
            _repository.CreateSuggestion(SuggestionModel);
            _repository.SaveChanges();
            SuggestionReadDto SuggestionReadDto = _mapper.Map<SuggestionReadDto>(SuggestionModel);
            return CreatedAtRoute(nameof(GetSuggestionById), new {Id = SuggestionReadDto.Id}, SuggestionReadDto);
        }

        // Put api/suggestion/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSuggestion(int id, SuggestionUpdateDto SuggestionUpdateDto){
            Suggestion SuggestionModel = _repository.GetSuggestionById(id);
            if(SuggestionModel == null){
                return NotFound();
            }
            _mapper.Map(SuggestionUpdateDto, SuggestionModel);
            _repository.UpdateSuggestion(SuggestionModel);
            _repository.SaveChanges();
            return NoContent();
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
            return NoContent();

        }
    }
}