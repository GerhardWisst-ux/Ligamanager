﻿using LigaManagerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Services.Contracts
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
