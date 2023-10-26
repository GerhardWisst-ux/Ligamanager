using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabellenManagement.Api.Models
{
    public interface ITabelleRepository
    {
        Task<IEnumerable<Tabelle>> GetTabellen();
        Task<Tabelle> GetTabelle(int TabelleId);
        Task<Tabelle> AddTabelle(Tabelle Tabelle);
        Task<Tabelle> UpdateTabelle(Tabelle Tabelle);
        Task<Tabelle> DeleteTabelle(int TabelleId);
    }
}
