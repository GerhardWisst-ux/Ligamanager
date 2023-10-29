using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Api.Models
{
    public interface ILigaRepository
    {
        Task<IEnumerable<Liga>> GetLigen();
        Task<Liga> GetLiga(int ligaIdId);
        Task<Liga> AddLiga(Liga ligaId);
        Task<Liga> UpdateLiga(Liga ligaId);
        Task<Liga> DeleteLiga(int ligaIdId);
    }
}
