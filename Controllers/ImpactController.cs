using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;
/*
namespace RSEBack.Controllers
{
    // api/impact
    [Route("api/impact")]
    [ApiController]
    public class ImpactController : ControllerBase
    {
        private readonly IImpactRepo _repository;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ImpactController(IImpactRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/projet/impact/{idUtilisateur}/{idProjet}
        [HttpGet("{id}", Name ="GetImpactById")]
        public ActionResult <ImpactReadDto> GetImpact(int idUtilisateur, int idProjet)
        {
            var ImpactItem = _repository.GetImpact(id);
            if(ImpactItem != null) return Ok(_mapper.Map<ImpactReadDto>(ImpactItem));
            else return NotFound();
        }

        // Post api/Impact
        [HttpPost]
        public ActionResult <Impact> CreateImpact(Impact ImpactCreateDto)
        {
            Impact ImpactModel = _mapper.Map<Impact>(ImpactCreateDto);
            _repository.CreateImpact(ImpactModel);
            _repository.SaveChanges();
            ImpactReadDto ImpactReadDto = _mapper.Map<ImpactReadDto>(ImpactModel);
            return CreatedAtRoute(nameof(GetImpactById), new {id = ImpactReadDto.Id}, ImpactReadDto);
        }

        // Put api/Impact/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateImpact(int id, ImpactUpdateDto ImpactUpdateDto){
            Impact ImpactModel = _repository.GetImpactById(id);
            if(ImpactModel == null){
                return NotFound();
            }
            _mapper.Map(ImpactUpdateDto, ImpactModel); // faire la mise à jour des données automatiquement 
            _repository.UpdateImpact(ImpactModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ImpactReadDto>(ImpactModel));
        }

        // Delete api/Impact/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteImpact(int id){
            
            Impact ImpactModel = _repository.GetImpactById(id);
            if(ImpactModel == null){
                return NotFound();
            }
            _repository.DeleteImpact(ImpactModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ImpactReadDto>(ImpactModel));
        }
    }
}
*/