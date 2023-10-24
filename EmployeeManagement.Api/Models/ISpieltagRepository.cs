using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpieltagManagement.Api.Models
{
    public interface ISpieltagRepository
    {
        Task<IEnumerable<Spieltag>> GetSpieltage();
        Task<Spieltag> GetSpieltag(int spieltagId);
        Task<Spieltag> GetAktSpieltag();
        Task<Spieltag> AddSpieltag(Spieltag Spieltag);
        Task<Spieltag> UpdateSpieltag(Spieltag Spieltag);
        Task<Spieltag> DeleteSpieltag(int SpieltagId);
    }
}
