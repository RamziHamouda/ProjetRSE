using System.Collections.Generic;
using RSEBack.Dtos;
using RSEBack.Models;


namespace RSEBack.Data{
    public interface IStatistiqueRepo{
        StatistiqueComptage GetStatistiqueComptage();
        StatistiquePourcentageImpact GetStatistiquePourcentageImpact();
        IEnumerable<StatistiqueContribution> GetStatistiqueContribution();
    }
}