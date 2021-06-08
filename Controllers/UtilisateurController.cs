using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;

namespace RSEBack.Controllers
{
    // api/Utilisateur
    [Route("api/utilisateur")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurRepo _repository;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public UtilisateurController(IUtilisateurRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/Utilisateur
        [HttpGet]
        public ActionResult <IEnumerable<UtilisateurReadDto>> GetAllUtilisateurs()
        {
            var UtilisateurItems = _repository.GetAllUtilisateur();
            return  Ok(_mapper.Map<IEnumerable<UtilisateurReadDto>>(UtilisateurItems));
        }

        // Get api/Utilisateur/{id}
        [HttpGet("{id}", Name ="GetUtilisateurById")]
        public ActionResult <UtilisateurReadDto> GetUtilisateurById(int id)
        {
            var UtilisateurItem = _repository.GetUtilisateurById(id);
            if(UtilisateurItem != null) return Ok(_mapper.Map<UtilisateurReadDto>(UtilisateurItem));
            else return NotFound();
        }

        // Post api/utilisateur
        [HttpPost]
        public ActionResult <Utilisateur> CreateUtilisateur(Utilisateur UtilisateurCreateDto)
        {
            Utilisateur UtilisateurModel = _mapper.Map<Utilisateur>(UtilisateurCreateDto);
            _repository.CreateUtilisateur(UtilisateurModel);
            _repository.SaveChanges();
            UtilisateurReadDto UtilisateurReadDto = _mapper.Map<UtilisateurReadDto>(UtilisateurModel);
            return CreatedAtRoute(nameof(GetUtilisateurById), new {Id = UtilisateurReadDto.Id}, UtilisateurReadDto);
        }

        // Put api/Utilisateur/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUtilisateur(int id, UtilisateurUpdateDto UtilisateurUpdateDto){
            Utilisateur UtilisateurModel = _repository.GetUtilisateurById(id);
            if(UtilisateurModel == null){
                return NotFound();
            }
            _mapper.Map(UtilisateurUpdateDto, UtilisateurModel);
            _repository.UpdateUtilisateur(UtilisateurModel);
            _repository.SaveChanges();
            return NoContent();
        }

        // Delete api/Utilisateur/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUtilisateur(int id){
            
            Utilisateur UtilisateurModel = _repository.GetUtilisateurById(id);
            if(UtilisateurModel == null){
                return NotFound();
            }
            _repository.DeleteUtilisateur(UtilisateurModel);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}