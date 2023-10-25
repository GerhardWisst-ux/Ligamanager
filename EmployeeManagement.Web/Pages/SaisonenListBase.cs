using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class SaisonenListBase : ComponentBase
    {
        public Int32 saison;

        //public List<DisplaySaison> SaisonenList;              

        [Inject]
        public ISaisonenService SaisonenService { get; set; }
              
        [Inject]
        public IVereineService VereineService { get; set; }

        public IEnumerable<Saison> Saisonen { get; set; }

        public IEnumerable<Verein> Vereine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Vereine = await VereineService.GetVereine();
            Saisonen = await SaisonenService.GetSaisonen();           
        }                    
        //public class DisplaySaison
        //{
        //    public DisplaySaison(string saisonID, string saisonname, string liganame, bool aktuell, bool abgeschlossen)
        //    {
        //        SaisonID = saisonID;
        //        Saisonname = saisonname;
        //        Liganame = liganame;
        //        Aktuell = aktuell;
        //        Abgeschlossen = abgeschlossen;
        //    }
        //    public string SaisonID { get; set; }
        //    public string Saisonname { get; set; }

        //    public string Liganame { get; set; }

        //    public bool Aktuell { get; set; }

        //    public bool Abgeschlossen { get; set; }

        //}

    }
}

