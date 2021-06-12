using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/impact
    [Route("api/projet/impact")]
    [ApiController]
    public class ImpactController : ControllerBase
    {
        private readonly IImpactRepo _repositoryImpact;
        private readonly IUtilisateurRepo _repositoryUtilisateur;
        private readonly IProjetRepo _repositoryProjet;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ImpactController(IImpactRepo repositoryImpact, IUtilisateurRepo repositoryUtilisateur, IProjetRepo repositoryProjet, IMapper mapper)
        {
            _repositoryImpact = repositoryImpact;
            _repositoryProjet = repositoryProjet;
            _repositoryUtilisateur = repositoryUtilisateur;
            _mapper = mapper;
        }

        [HttpGet("{idImpact}", Name ="GetImpactById")]
        public ActionResult <ImpactReadDto> GetImpactById(int idImpact)
        {
            var ImpactItem = _repositoryImpact.GetImpactById(idImpact);
            if(ImpactItem != null) return Ok(_mapper.Map<ImpactReadDto>(ImpactItem));
            else return NotFound();
        }

        // Get api/projet/impact/{idUtilisateur}/{idProjet}
        [HttpGet("{idUtilisateur}/{idProjet}")]
        public ActionResult <IEnumerable<ImpactReadDto>> GetImpact(int idUtilisateur, int idProjet)
        {
            Utilisateur utilisateur = _repositoryUtilisateur.GetUtilisateurById(idUtilisateur);
            Projet projet = _repositoryProjet.GetProjetById(idProjet);
            if(utilisateur == null || projet == null)
                return NotFound();
            IEnumerable<Impact> ListeImpact = _repositoryImpact.GetImpact(utilisateur, projet);
            if(ListeImpact != null) return Ok(_mapper.Map<IEnumerable<ImpactReadDto>>(ListeImpact));
            else return NotFound();
        }

        // Post api/projet/impact
        [HttpPost]
        public ActionResult <Impact> CreateImpact(ImpactCreateDto ImpactCreateDto)
        {
            Utilisateur utilisateur = _repositoryUtilisateur.GetUtilisateurById(ImpactCreateDto.IdUtilisateur);
            Projet projet = _repositoryProjet.GetProjetById(ImpactCreateDto.IdProjet);
            if(utilisateur == null || projet == null)
                return NotFound();
            Impact ImpactModel = _mapper.Map<Impact>(ImpactCreateDto);
            _repositoryImpact.CreateImpact(ImpactModel);
            _repositoryImpact.SaveChanges();
            ImpactReadDto ImpactReadDto = _mapper.Map<ImpactReadDto>(ImpactModel);
            return CreatedAtRoute(nameof(GetImpactById), new {idImpact = ImpactReadDto.IdImpact}, ImpactReadDto);
        }

        // Put api/projet/impact
        [HttpPut]
        public ActionResult UpdateImpact(ImpactUpdateDto ImpactUpdateDto){
            Impact ImpactModel = _repositoryImpact.GetImpactById(ImpactUpdateDto.IdImpact);
            if(ImpactModel == null){
                return NotFound();
            }
            if(_repositoryProjet.GetProjetById(ImpactUpdateDto.IdProjet) == null || _repositoryUtilisateur.GetUtilisateurById(ImpactUpdateDto.IdUtilisateur) == null)
                return NotFound();
            _mapper.Map(ImpactUpdateDto, ImpactModel); 
            _repositoryImpact.UpdateImpact(ImpactModel);
            _repositoryImpact.SaveChanges();
            return Ok(_mapper.Map<ImpactReadDto>(ImpactModel));
        }

        // Delete api/Impact/{id}
        [HttpDelete("{idImpact}")]
        public ActionResult DeleteImpact(int idImpact){
            
            Impact ImpactModel = _repositoryImpact.GetImpactById(idImpact);
            if(ImpactModel == null){
                return NotFound();
            }
            _repositoryImpact.DeleteImpact(ImpactModel);
            _repositoryImpact.SaveChanges();
            return Ok(_mapper.Map<ImpactReadDto>(ImpactModel));
        }
    }
}
