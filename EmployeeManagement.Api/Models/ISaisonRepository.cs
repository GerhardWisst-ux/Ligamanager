using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpieltagManagement.Api.Models
{
    public interface ISaisonRepository
    {
        Task<IEnumerable<Saison>> GetSaisonen();
        Task<Saison> GetSaison(int SaisonId);
        Task<Saison> AddSaison(Saison Saison);
        Task<Saison> UpdateSaison(Saison Saison);
        Task<Saison> DeleteSaison(int SaisonId);
    }
}
