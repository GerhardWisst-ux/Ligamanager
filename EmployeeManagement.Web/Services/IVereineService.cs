using LigaManagerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Services
{
    public interface IVereineService
    {
        Task<IEnumerable<Verein>> GetVereine();
        Task<Verein> GetVerein(int id);
        Task<Verein> UpdateVerein(Verein updatedVerein);
        Task<Verein> CreateVerein(Verein newVerein);
        Task DeleteVerein(int id);

    }
}
