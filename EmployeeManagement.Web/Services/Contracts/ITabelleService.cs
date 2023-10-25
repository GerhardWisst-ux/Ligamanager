using LigaManagerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Services.Contracts
{
    public interface ITabelleService
    {
        Task<IEnumerable<Tabelle>> GetTabellen();
        Task<Tabelle> GetTabelle(int id);
        Task<IEnumerable<Tabelle>> BerechneTabelle(ISpieltagService spieltagService, IEnumerable<Verein> vereine, int iSpieltag);
        Task<Tabelle> UpdateTabelle(Tabelle updatedTabelle);
        Task<Tabelle> CreateTabelle(Tabelle newTabelle);
        Task DeleteTabelle(int id);

    }
}
