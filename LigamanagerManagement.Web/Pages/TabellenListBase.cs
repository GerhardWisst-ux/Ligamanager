using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class TabellenListBase : ComponentBase
    {
        public Int32 spieltag;

        public List<DisplaySpieltag> SpieltagList;

        protected string selectedspieltagID;

        protected string SelectedspieltagID
        {
            get => selectedspieltagID;
            set { selectedspieltagID = value; }
        }

        [Inject]
        public ITabelleService TabelleService { get; set; }

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        [Inject]
        public IVereineService VereineService { get; set; }

        public IEnumerable<Tabelle> Tabellen { get; set; }

        public IEnumerable<Verein> Vereine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SpieltagList = new List<DisplaySpieltag>();

            for (int i = 1; i <= 34; i++)
            {
                SpieltagList.Add(new DisplaySpieltag(i.ToString(), i.ToString() + ".Spieltag"));
            }

            Vereine = await VereineService.GetVereine();
            Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, 1);                        
        }
        
        protected async Task TabelleDeleted()
        {
            Tabellen = (await TabelleService.GetTabellen()).ToList();
        }

        protected async void SelectedSpieltagChanged(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                spieltag = Convert.ToInt32(e.Value);
                Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, spieltag);
            }
        }
        public async Task SpieltagChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                spieltag = Convert.ToInt32(e.Value);
                Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, spieltag);                
            }
        }

        public class DisplaySpieltag
        {

            public DisplaySpieltag(string nummer, string name)
            {
                Nummer = nummer;
                Name = name;
            }
            public string Nummer { get; set; }
            public string Name { get; set; }

        }
    }
}

