using LigaManagerManagement.Models;
using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Services
{
    public interface ISpieltagService
    {
        Task<IEnumerable<Spieltag>> GetSpieltage();
        Task<Spieltag> GetSpieltag(int id);
        Task<Spieltag> UpdateSpieltag(Spieltag updatedSpieltag);
        Task<Spieltag> CreateSpieltag(Spieltag newSpieltag);
        Task DeleteSpieltag(int id);

    }
}
