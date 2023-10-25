using LigaManagerManagement.Models;
using Microsoft.EntityFrameworkCore;
using SpieltagManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LigaManagerManagement.Api.Models
{
    public class SaisonRepository : ISaisonRepository
    {
        private readonly AppDbContext appDbContext;

        public SaisonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Saison> AddSaison(Saison Saison)
        {
            var result = await appDbContext.Saisonen.AddAsync(Saison);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Saison> DeleteSaison(int SaisonId)
        {
            var result = await appDbContext.Saisonen
               .FirstOrDefaultAsync(e => e.SaisonID == SaisonId);
            if (result != null)
            {
                appDbContext.Saisonen.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Saison> GetSaison(int SaisonId)
        {
            return await appDbContext.Saisonen
                .FirstOrDefaultAsync(d => d.SaisonID == SaisonId);
        }

        public async Task<IEnumerable<Saison>> GetSaisonen()
        {
            return await appDbContext.Saisonen.ToListAsync();
        }

        public async Task<Saison> UpdateSaison(Saison Saison)
        {
            var result = await appDbContext.Saisonen.AddAsync(Saison);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

