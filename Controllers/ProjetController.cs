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
        private readonly IProjetRepo _repositoryProjet;
        private readonly IUtilisateurRepo _repositoryUtilisateur;
        private readonly IPartenaireRepo _repositoryPartenaire;

        private readonly IMapper _mapper;

        //ctor for dependency injection
        public ProjetController(IProjetRepo repositoryProjet, IUtilisateurRepo repositoryUtilisateur, IPartenaireRepo repositoryPartenaire, IMapper mapper)
        {
            _repositoryProjet = repositoryProjet;
            _repositoryUtilisateur = repositoryUtilisateur;
            _repositoryPartenaire = repositoryPartenaire;
            _mapper = mapper;
        }

        // Get api/Projet
        [HttpGet]
        public ActionResult <IEnumerable<ProjetReadDto>> GetAllProjets()
        {
            var ProjetItems = _repositoryProjet.GetAllProjet();
            return  Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetItems));
        }

        // Get api/projet/parCategorie/{categorie}
        [HttpGet("parCategorie/{categorie}")]
        public ActionResult <IEnumerable<ProjetReadDto>> GetProjetParCategorie(string categorie)
        {
            var ProjetItems = _repositoryProjet.GetProjetParCategorie(categorie);
            return  Ok(_mapper.Map<IEnumerable<ProjetReadDto>>(ProjetItems));
        }

        [HttpGet("{id}", Name ="GetProjetById")]
        public ActionResult <ProjetReadDto> GetProjetById(int id)
        {
            var ProjetItem = _repositoryProjet.GetProjetById(id);
            if(ProjetItem != null) return Ok(_mapper.Map<ProjetReadDto>(ProjetItem));
            else return NotFound();
        }

        // Post api/projet
        [HttpPost]
        public ActionResult <Projet> CreateProjet(ProjetCreateDto ProjetCreateDto)
        {
            Projet ProjetModel = _mapper.Map<Projet>(ProjetCreateDto);
            if(! _repositoryPartenaire.IsExistListePartenaires(ProjetCreateDto.Partenaires)){
                return NotFound();
            }
            _repositoryProjet.CreateProjet(ProjetModel, ProjetCreateDto.Partenaires);
            _repositoryProjet.SaveChanges();
            ProjetReadDto ProjetReadDto = _mapper.Map<ProjetReadDto>(ProjetModel);
            return CreatedAtRoute(nameof(GetProjetById), new {id = ProjetReadDto.Id}, ProjetReadDto);
        }

        // Put api/Projet
        [HttpPut]
        public ActionResult UpdateProjet(ProjetUpdateDto ProjetUpdateDto){
            Projet ProjetModel = _repositoryProjet.GetProjetById(ProjetUpdateDto.Id);
            if(ProjetModel == null){
                return NotFound();
            }
            if(! _repositoryPartenaire.IsExistListePartenaires(ProjetUpdateDto.Partenaires)){
                return NotFound();
            }
            _mapper.Map(ProjetUpdateDto, ProjetModel); // faire la mise à jour des données automatiquement 
            _repositoryProjet.UpdateProjet(ProjetModel, ProjetUpdateDto.Partenaires);
            _repositoryProjet.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }

        // Put api/projet/vue{idProjet}
        [HttpPut("vue/{idProjet}")]
        public ActionResult UpdateVuesProjet(int idProjet){
            Projet ProjetModel = _repositoryProjet.GetProjetById(idProjet);
            if(ProjetModel == null){
                return NotFound();
            }
            _repositoryProjet.UpdateVuesProjet(ProjetModel);
            _repositoryProjet.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }

        // Delete api/Projet/{id}
        [HttpDelete("{idProjet}")]
        public ActionResult DeleteProjet(int idProjet){
            
            Projet ProjetModel = _repositoryProjet.GetProjetById(idProjet);
            if(ProjetModel == null){
                return NotFound();
            }
            _repositoryProjet.DeleteProjet(ProjetModel);
            _repositoryProjet.SaveChanges();
            return Ok(_mapper.Map<ProjetReadDto>(ProjetModel));
        }
    }
}