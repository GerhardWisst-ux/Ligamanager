using LigaManagerManagement.Models;
using Microsoft.EntityFrameworkCore;
using SpieltagManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigaManagerManagement.Api.Models
{
    public class SpieltagRepository : ISpieltagRepository
    {
        private readonly AppDbContext appDbContext;

        public SpieltagRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Spieltag> AddSpieltag(Spieltag spieltag)
        {
            var result = await appDbContext.Spieltage.AddAsync(spieltag);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Spieltag> DeleteSpieltag(int SpieltagId)
        {
            var result = await appDbContext.Spieltage
               .FirstOrDefaultAsync(e => e.SpieltagId == SpieltagId);
            if (result != null)
            {
                appDbContext.Spieltage.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public Task<Spieltag> GetAktSpieltag()
        {
            throw new NotImplementedException();
        }

        public async Task<Spieltag> GetSpieltag(int SpieltagId)
        {
            return await appDbContext.Spieltage               
                .FirstOrDefaultAsync(d => d.SpieltagId == SpieltagId);
        }

        public async Task<IEnumerable<Spieltag>> GetSpieltage()
        {
            return await appDbContext.Spieltage                
                .ToListAsync();
        }

        public async Task<Spieltag> UpdateSpieltag(Spieltag spieltag)
        {
            var result = await appDbContext.Spieltage.AddAsync(spieltag);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

