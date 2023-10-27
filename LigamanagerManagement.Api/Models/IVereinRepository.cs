using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpieltagManagement.Api.Models
{
    public interface IVereinRepository
    {
        Task<IEnumerable<Verein>> GetVereine();
        Task<Verein> GetVerein(int Id);
        Task<Verein> AddVerein(Verein Verein);
        Task<Verein> UpdateVerein(Verein Verein);
        Task<Verein> DeleteVerein(int VereinId);
    }
}
