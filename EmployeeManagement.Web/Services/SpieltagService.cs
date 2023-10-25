using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Services
{
    public class SpieltagService : ISpieltagService

    {
        private readonly HttpClient httpClient;

        public SpieltagService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Spieltag> GetSpieltag(int id)
        {
            return await httpClient.GetJsonAsync<Spieltag>($"api/spieltage/{id}");
        }

        public async Task<IEnumerable<Spieltag>> GetSpieltage()
        {
            return await httpClient.GetJsonAsync<Spieltag[]>("api/spieltage");
        }

        public async Task<Spieltag> CreateSpieltag(Spieltag newSpieltag)
        {
            return await httpClient.PostJsonAsync<Spieltag>("api/spieltage", newSpieltag);
        }
               
        public async Task<Spieltag> UpdateSpieltag(Spieltag updatedSpieltag)
        {
            return await httpClient.PutJsonAsync<Spieltag>("api/spieltage", updatedSpieltag);
        }

        public async Task DeleteSpieltag(int id)
        {
            await httpClient.DeleteAsync($"api/spieltage/{id}");
        }
    }
}
