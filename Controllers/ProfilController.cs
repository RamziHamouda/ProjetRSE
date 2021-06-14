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

        // Get api/profil/statistique/idUtilisateur
        [HttpGet("statistique/{idUtilisateur}")]
        public ActionResult <ProfilStatistique> GetStatistiqueProfil(int idUtilisateur)
        {
            Utilisateur utilisateur = _repositoryUtilisateur.GetUtilisateurById(idUtilisateur);
            if(utilisateur == null)
                return NotFound();
            var StatistiquesProfil = _repositoryProfil.GetStatistique(utilisateur);
            return  Ok(StatistiquesProfil);
        }

        
        // Put api/profil/changerMotDePasse
        [HttpPut("changerMotDePasse")]
        public ActionResult UpdateMotDePasse(UtilisateurMdpUpdateDto utilisateurMdpUpdateDto){
            Utilisateur UtilisateurModel = _repositoryUtilisateur.GetUtilisateurById(utilisateurMdpUpdateDto.Id);
            if(UtilisateurModel == null || !UtilisateurModel.Email.Equals(utilisateurMdpUpdateDto.Email)){
                return NotFound();
            }
            _repositoryProfil.UpdateMotDePasse(utilisateurMdpUpdateDto.Id, utilisateurMdpUpdateDto.MotDePasse);
            _repositoryProfil.SaveChanges();
            return Ok(_mapper.Map<UtilisateurReadDto>(UtilisateurModel));
        }

        // GET api/profil/
        [HttpGet]
        public ActionResult GetUtilisateur(UtilisateurMdpReadDto utilisateurMdpReadDto){
            Utilisateur UtilisateurModel = _repositoryUtilisateur.GetUtilisateur(utilisateurMdpReadDto.Email, utilisateurMdpReadDto.MotDePasse);
            if(UtilisateurModel == null){
                return NotFound();
            }
            return Ok(_mapper.Map<UtilisateurReadDto>(UtilisateurModel));
        }

        // Put api/profil
        [HttpPut]
        public ActionResult UpdateProfil(UtilisateurUpdateDto utilisateurUpdateDto){
            Utilisateur UtilisateurModel = _repositoryUtilisateur.GetUtilisateurById(utilisateurUpdateDto.Id);
            if(UtilisateurModel == null){
                return NotFound();
            }
            _mapper.Map(utilisateurUpdateDto, UtilisateurModel);
            _repositoryProfil.UpdateUtilisateur(UtilisateurModel);
            _repositoryProfil.SaveChanges();
            return Ok(_mapper.Map<UtilisateurReadDto>(UtilisateurModel));
        }

    }
}