using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/projet
    [Route("api/projet")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetRepo _repository;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ProjetController(IProjetRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/Projet
        [HttpGet]
        public ActionResult <IEnumerable<ProjetReadDto>> GetAllProjets()
        {
            var ProjetItems = _repository.GetAllProjet();
            return  Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetItems));
        }
        [HttpGet("{id}", Name ="GetProjetById")]
        public ActionResult <ProjetReadDto> GetProjetById(int id)
        {
            var ProjetItem = _repository.GetProjetById(id);
            if(ProjetItem != null) return Ok(_mapper.Map<ProjetReadDto>(ProjetItem));
            else return NotFound();
        }

        // Post api/projet
        [HttpPost]
        public ActionResult <Projet> CreateProjet(Projet ProjetCreateDto)
        {
            Projet ProjetModel = _mapper.Map<Projet>(ProjetCreateDto);
            _repository.CreateProjet(ProjetModel);
            _repository.SaveChanges();
            ProjetReadDto ProjetReadDto = _mapper.Map<ProjetReadDto>(ProjetModel);
            return CreatedAtRoute(nameof(GetProjetById), new {id = ProjetReadDto.Id}, ProjetReadDto);
        }

        // Put api/Projet
        [HttpPut]
        public ActionResult UpdateProjet(ProjetUpdateDto ProjetUpdateDto){
            Projet ProjetModel = _repository.GetProjetById(ProjetUpdateDto.Id);
            if(ProjetModel == null){
                return NotFound();
            }
            _mapper.Map(ProjetUpdateDto, ProjetModel); // faire la mise à jour des données automatiquement 
            _repository.UpdateProjet(ProjetModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }

        // Put api/Projet/{idProjet}
        [HttpPut("{idProjet}")]
        public ActionResult UpdateAimeProjet(int idProjet, int idUtilisateur){
            Projet ProjetModel = _repository.GetProjetById(idProjet);
            if(ProjetModel == null){
                return NotFound();
            }
            _repository.UpdateAimeProjet(ProjetModel, idUtilisateur);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }

        // Put api/projet/vue{idProjet}
        [HttpPut("{idProjet}")]
        public ActionResult UpdateVuesProjet(int idProjet){
            Projet ProjetModel = _repository.GetProjetById(idProjet);
            if(ProjetModel == null){
                return NotFound();
            }
            _repository.UpdateVuesProjet(ProjetModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }

        // Delete api/Projet/{id}
        [HttpDelete("{idProjet}")]
        public ActionResult DeleteProjet(int idProjet){
            
            Projet ProjetModel = _repository.GetProjetById(idProjet);
            if(ProjetModel == null){
                return NotFound();
            }
            _repository.DeleteProjet(ProjetModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }
    }
}