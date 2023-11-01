using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class TabellenListBase : ComponentBase
    {
        public Int32 currentspieltag = 1;
        public string saison;

        public List<DisplaySpieltag> SpieltagList;

        [Inject]
        public ISaisonenService SaisonenService { get; set; }

        public List<DisplaySaison> SaisonenList;

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
        
        public IEnumerable<Saison> Saisonen { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                SpieltagList = new List<DisplaySpieltag>();
                SaisonenList = new List<DisplaySaison>();
                
                Saisonen = (await SaisonenService.GetSaisonen()).ToList();
                for (int i = 1; i <= 34; i++)
                {
                    SpieltagList.Add(new DisplaySpieltag(i.ToString(), i.ToString() + ".Spieltag"));
                }

                for (int i = 0; i < Saisonen.Count(); i++)
                {
                    var columns = Saisonen.ElementAt(i);
                    SaisonenList.Add(new DisplaySaison(columns.SaisonID, columns.Saisonname));
                }

                saison = Ligamanager.Components.Globals.currentSaison;
                currentspieltag = SpieltagList.Count;
                Vereine = await VereineService.GetVereine();
                Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, SpieltagList.Count, Ligamanager.Components.Globals.currentSaison);
            }
            catch (Exception ex)
            {

                Debug.Print(ex.Message);
            }
        }
                     

        public async Task SaisonChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                saison = e.Value.ToString();
                Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, currentspieltag, saison);
            }
        }
        public async Task SpieltagChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                currentspieltag = Convert.ToInt32(e.Value);
                Tabellen = await TabelleService.BerechneTabelle(SpieltagService, Vereine, currentspieltag, Ligamanager.Components.Globals.currentSaison);
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

        public class DisplaySaison
        {

            public DisplaySaison(int saisonID, string saisonname)
            {
                SaisonID = saisonID;
                Saisonname = saisonname;
            }
            public int SaisonID { get; set; }
            public string Saisonname { get; set; }
        }
    }
}

