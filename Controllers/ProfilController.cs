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
        [HttpGet("{idUtilisateur}")]
        public ActionResult <IEnumerable<ProjetReadDto>> GetProjets(int idUtilisateur)
        {
            Utilisateur utilisateur = _repositoryUtilisateur.GetUtilisateurById(idUtilisateur);
            if(utilisateur == null)
                return NotFound();
            var ProjetItems = _repositoryProfil.GetProjets(utilisateur);
            return  Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetItems));
        }

        /*
        // Get api/actualite/{id}
        [HttpGet("{id}", Name ="GetActualiteById")]
        public ActionResult <ActualiteReadDto> GetActualiteById(int id)
        {
            var ActualiteItem = _repository.GetActualiteById(id);
            if(ActualiteItem != null) return Ok(_mapper.Map<ActualiteReadDto>(ActualiteItem));
            else return NotFound();
        }

        // Post api/actualite
        [HttpPost]
        public ActionResult <Actualite> CreateActualite(Actualite ActualiteCreateDto)
        {
            Actualite ActualiteModel = _mapper.Map<Actualite>(ActualiteCreateDto);
            _repository.CreateActualite(ActualiteModel);
            _repository.SaveChanges();
            ActualiteReadDto ActualiteReadDto = _mapper.Map<ActualiteReadDto>(ActualiteModel);
            return CreatedAtRoute(nameof(GetActualiteById), new {id = ActualiteReadDto.Id}, ActualiteReadDto);
        }

        // Put api/actualite/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateActualite(int id, ActualiteUpdateDto ActualiteUpdateDto){
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