using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;

namespace LigaManagerManagement.Web.Services
{
    public class VereineService : IVereineService
    {
        private readonly HttpClient httpClient;

        public VereineService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
              
        public Task<Verein> CreateVerein(Verein newVerein)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVerein(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Verein> GetVerein(int id)
        {
            return await httpClient.GetJsonAsync<Verein>($"api/vereine/{id}");
        }

        public async Task<IEnumerable<Verein>> GetVereine()
        {
            return await httpClient.GetJsonAsync<Verein[]>("api/vereine");
        }

        public async Task<Verein> UpdateVerein(Verein updatedVerein)
        {
            return await httpClient.PutJsonAsync<Verein>("api/vereine", updatedVerein);
        }

        
    }
}
