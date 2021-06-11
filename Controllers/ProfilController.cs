using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

/*
namespace RSEBack.Controllers
{
    // api/Profil
    [Route("api/Profil")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly IUtilisateurRepo _repositoryUtilisateur;
        private readonly IProjetRepo _repositoryProjet;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ProfilController(IUtilisateurRepo repository, IMapper mapper)
        {
            _repositoryUtilisateur = repository;
            _mapper = mapper;
        }

        // Get api/profil/projets/{idUtilisateur}
        [HttpGet("{idUtilisateur}"]
        public ActionResult <IEnumerable<ProjetReadDto>> GetProjetsAimesById(int idUtilisateur)
        {
            var ProjetsAimes = _repositoryProjet.GetProjetsAimesById(idUtilisateur);
            if(ProjetsAimes != null) return Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetsAimes));
            else return NotFound();
        }

        // Put api/profil/changerMotDePasse
        [HttpPut("{changerMotDePasse}")]
        public ActionResult UpdateProfil(int id, ProfilUpdateDto ProfilUpdateDto){
            Profil ProfilModel = _repository.GetProfilById(id);
            if(ProfilModel == null){
                return NotFound();
            }
            _mapper.Map(ProfilUpdateDto, ProfilModel);
            _repository.UpdateProfil(ProfilModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProfilReadDto>(ProfilModel));
        }

        // Delete api/Profil/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProfil(int id){
            
            Profil ProfilModel = _repository.GetProfilById(id);
            if(ProfilModel == null){
                return NotFound();
            }
            _repository.DeleteProfil(ProfilModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ProfilReadDto>(ProfilModel));
        }
    }
}
*/