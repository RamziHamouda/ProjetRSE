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

        // Get api/utilisateur
        [HttpGet]
        public ActionResult <IEnumerable<UtilisateurReadDto>> GetAllUtilisateurs() // retourner les employés
        {
            var UtilisateurItems = _repository.GetAllUtilisateur();
            return  Ok(_mapper.Map<IEnumerable<UtilisateurReadDto>>(UtilisateurItems));
        }

        // Get api/Utilisateur/equipeRSE
        [HttpGet("equipeRSE")]
        public ActionResult <UtilisateurReadDto> GetAllUtilisateurEquipeRSE() // membres d'equipe RSE
        {
            var UtilisateurItems = _repository.GetAllUtilisateurEquipeRSE();
            return Ok(_mapper.Map<IEnumerable<UtilisateurEquipeRSEReadDto>>(UtilisateurItems));
        }

        // Put api/utilisateur/equipeRSE/{id}
        [HttpPut("equipeRSE/{id}")]
        public ActionResult UpdateUtilisateur(int idUtilisateur){
            Utilisateur UtilisateurModel = _repository.GetUtilisateurById(idUtilisateur);
            if(UtilisateurModel == null){
                return NotFound();
            }
            _repository.UpdateUtilisateur(UtilisateurModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<UtilisateurReadDto>(UtilisateurModel));
        }
    }
}