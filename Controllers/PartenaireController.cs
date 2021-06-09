using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/partenaire
    [Route("api/partenaire")]
    [ApiController]
    public class PartenaireController : ControllerBase
    {
        private readonly IPartenaireRepo _repository;
        private readonly IMapper _mapper;

        //ctor for dependency injection
        public PartenaireController(IPartenaireRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/partenaire
        [HttpGet]
        public ActionResult <IEnumerable<PartenaireReadDto>> GetAllPartenaires()
        {
            var PartenaireItems = _repository.GetAllPartenaire();
            return  Ok(_mapper.Map<IEnumerable<PartenaireReadDto>>(PartenaireItems));
        }

        // Get api/partenaire/{id}
        [HttpGet("{id}", Name ="GetPartenaireById")]
        public ActionResult <PartenaireReadDto> GetPartenaireById(int id)
        {
            var PartenaireItem = _repository.GetPartenaireById(id);
            if(PartenaireItem != null) return Ok(_mapper.Map<PartenaireReadDto>(PartenaireItem));
            else return NotFound();
        }

        // Post api/partenaire
        [HttpPost]
        public ActionResult <Partenaire> CreatePartenaire(Partenaire PartenaireCreateDto)
        {
            Partenaire PartenaireModel = _mapper.Map<Partenaire>(PartenaireCreateDto);
            _repository.CreatePartenaire(PartenaireModel);
            _repository.SaveChanges();
            PartenaireReadDto PartenaireReadDto = _mapper.Map<PartenaireReadDto>(PartenaireModel);
            return CreatedAtRoute(nameof(GetPartenaireById), new {Id = PartenaireReadDto.Id}, PartenaireReadDto);
        }

        // Put api/partenaire/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePartenaire(int id, PartenaireUpdateDto PartenaireUpdateDto){
            Partenaire PartenaireModel = _repository.GetPartenaireById(id);
            if(PartenaireModel == null){
                return NotFound();
            }
            _mapper.Map(PartenaireUpdateDto, PartenaireModel);
            _repository.UpdatePartenaire(PartenaireModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<PartenaireReadDto>(PartenaireModel));
        }

        // Delete api/partenaire/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePartenaire(int id){
            
            Partenaire PartenaireModel = _repository.GetPartenaireById(id);
            if(PartenaireModel == null){
                return NotFound();
            }
            _repository.DeletePartenaire(PartenaireModel);
            _repository.SaveChanges();
            return Ok(_mapper.Map<PartenaireReadDto>(PartenaireModel));
        }
    }
}