using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using RSEBack.Data;
using RSEBack.Models;
using RSEBack.Dtos;

namespace RSEBack.Controllers
{
    // api/statistique
    [Route("api/statistique")]
    [ApiController]
    public class StatistiqueController : ControllerBase
    {
        private readonly IStatistiqueRepo _repository;

        //ctor for dependency injection
        public StatistiqueController(IStatistiqueRepo repository)
        {
            _repository = repository;
        }

        // Get api/statistique/comptage
        [HttpGet("comptage")]
        public ActionResult <StatistiqueComptage> GetStatistiqueComptage()
        {
            StatistiqueComptage StatistiquesComptage = _repository.GetStatistiqueComptage();
            return  Ok(StatistiquesComptage);
        }

        // Get api/statistique/pourcentageImpact
        [HttpGet("pourcentageImpact")]
        public ActionResult <StatistiquePourcentageImpact> GetStatistiquePourcentageImpact()
        {
            StatistiquePourcentageImpact statistiquePourcentageImpact = _repository.GetStatistiquePourcentageImpact();
            return  Ok(statistiquePourcentageImpact);
        }

        // Get api/statistique/projet
        [HttpGet("projet")]
        public ActionResult <IEnumerable<StatistiqueContribution>> GetStatistiqueContribution()
        {
            IEnumerable<StatistiqueContribution> statistiqueContributions = _repository.GetStatistiqueContribution();
            return  Ok(statistiqueContributions);
        }
    }
}