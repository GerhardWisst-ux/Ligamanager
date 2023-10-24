using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class SpieltagListBase : ComponentBase
    {
        public Int32 currentspieltag = 1;

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        [Inject]
        public IVereineService VereineService { get; set; }
        public IEnumerable<Spieltag> Spieltage { get; set; }
        public IEnumerable<Verein> Vereine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Vereine = await VereineService.GetVereine();

            Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == "8");
            
            for (int i = 0; i < Spieltage.Count(); i++)
            {
                var columns = Spieltage.ElementAt(i);
                columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
            }         
        }

        protected async Task SpieltagDeleted()
        {
            Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == "1").ToList();
        }

       
       protected void SelectedSpieltagChanged(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                currentspieltag = Convert.ToInt32(e.Value);
            
            }
        }
    }
}
