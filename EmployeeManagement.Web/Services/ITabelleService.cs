using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Services
{
    public interface ITabelleService
    {
        Task<IEnumerable<Tabelle>> GetTabellen();
        Task<Tabelle> GetTabelle(int id);
        Task<IEnumerable<Tabelle>> BerechneTabelle(ISpieltagService spieltagService,IEnumerable<Verein> vereine, int iSpieltag);        
        Task<Tabelle> UpdateTabelle(Tabelle updatedTabelle);
        Task<Tabelle> CreateTabelle(Tabelle newTabelle);
        Task DeleteTabelle(int id);

    }
}
