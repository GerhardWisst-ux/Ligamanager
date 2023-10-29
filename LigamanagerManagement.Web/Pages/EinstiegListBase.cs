using LigamanagerManagement.Web.Pages;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class EinstiegListBase : ComponentBase
    {
        [Inject]
        public ISaisonenService SaisonenService { get; set; }

        public List<DisplaySaison> SaisonenList;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IVereineService _VereineService { get; set; }

        public IEnumerable<Saison> Saisonen { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SaisonenList = new List<DisplaySaison>();
            Saisonen = (await SaisonenService.GetSaisonen()).ToList();

            for (int i = 0; i < Saisonen.Count(); i++)
            {
                var columns = Saisonen.ElementAt(i);
                SaisonenList.Add(new DisplaySaison(columns.SaisonID, columns.Saisonname));
            }

            if (DateTime.Now.Month > 6)
            {
                Ligamanager.Components.Globals.currentSaison = DateTime.Now.Year + "/" + (DateTime.Now.Year + 1);
            }
            else
            {
                Ligamanager.Components.Globals.currentSaison = (DateTime.Now.Year - 1) + "/" + DateTime.Now.Year;
            }
            Ligamanager.Components.Globals.currentLiga = "Bundesliga";

        }

        public void SaisonChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Ligamanager.Components.Globals.currentSaison = e.Value.ToString();
            }
        }

        public void LigaChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Ligamanager.Components.Globals.currentLiga = e.Value.ToString();
            }
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

        public async void OnClickHandler()
        {
            Ligamanager.Components.Globals.VereinAktSaison = (await _VereineService.GetVereine()).Take(18);
            NavigationManager.NavigateTo("spieltage", true);

        }
    }
}
