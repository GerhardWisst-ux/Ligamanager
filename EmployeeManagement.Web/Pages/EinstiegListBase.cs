using LigamanagerManagement.Web.Pages;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class EinstiegListBase : ComponentBase
    {
        public Int32 currentSaison;

        [Inject]
        public ISaisonenService SaisonenService { get; set; }

        public List<DisplaySaison> SaisonenList;

        public IEnumerable<Saison> Saisonen { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SaisonenList = new List<DisplaySaison>();
            Saisonen = (await SaisonenService.GetSaisonen()).ToList();                      

            for (int i = 1; i < Saisonen.Count(); i++)
            {
                var columns = Saisonen.ElementAt(i);
                SaisonenList.Add(new DisplaySaison(columns.SaisonID, columns.Saisonname));                
            }            
        }

        public async Task SaisonChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                currentSaison = Convert.ToInt32(e.Value);
                Saisonen = (await SaisonenService.GetSaisonen()).ToList();
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
    }
}
