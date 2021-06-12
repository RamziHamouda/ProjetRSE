using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/profil
    [Route("api/profil")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly IProfilRepo _repositoryProfil;
        private readonly IUtilisateurRepo _repositoryUtilisateur;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ProfilController(IProfilRepo repositoryProfil, IUtilisateurRepo repositoryUtilisateur, IMapper mapper)
        {
            _repositoryProfil = repositoryProfil;
            _repositoryUtilisateur = repositoryUtilisateur;
            _mapper = mapper;
        }

        // Get api/profil/projets/idutilisateur
        [HttpGet("projets/{idUtilisateur}")]
        public ActionResult <IEnumerable<ProjetReadDto>> GetProjets(int idUtilisateur)
        {
            Utilisateur utilisateur = _repositoryUtilisateur.GetUtilisateurById(idUtilisateur);
            if(utilisateur == null)
                return NotFound();
            var ProjetItems = _repositoryProfil.GetProjets(utilisateur);
            return  Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetItems));
        }

        /*
        // Put api/profil/changerMotDePasse
        [HttpPut("changerMotDePasse")]
        public ActionResult UpdateMotDePasse(UtilisateurMdpUpdateDto utilisateurMdpUpdateDto){
            Actualite ActualiteModel = _repository.GetActualiteById(id);
            if(ActualiteModel == null){
                return NotFound();
            }
            _mapper.Map(ActualiteUpdateDto, ActualiteModel); // faire la mise à jour des données automatiquement 
            _repository.UpdateActualite(ActualiteModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ActualiteReadDto>(ActualiteModel));
        }

        // Delete api/actualite/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteActualite(int id){
            
            Actualite ActualiteModel = _repository.GetActualiteById(id);
            if(ActualiteModel == null){
                return NotFound();
            }
            _repository.DeleteActualite(ActualiteModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<ActualiteReadDto>(ActualiteModel));
        }
        */
    }
}