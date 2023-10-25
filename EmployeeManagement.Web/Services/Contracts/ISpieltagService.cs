using LigaManagerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Services.Contracts
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
