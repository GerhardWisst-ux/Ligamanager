using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class SpieltagListBase : ComponentBase
    {
        public Int32 currentspieltag = 1;

        public List<DisplaySpieltag> SpieltagList;

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        [Inject]
        public IVereineService VereineService { get; set; }
        public IEnumerable<Spieltag> Spieltage { get; set; }
        public IEnumerable<Verein> Vereine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                SpieltagList = new List<DisplaySpieltag>();

                for (int i = 1; i <= 34; i++)
                {
                    SpieltagList.Add(new DisplaySpieltag(i.ToString(), i.ToString() + ".Spieltag"));
                }

                Vereine = await VereineService.GetVereine();

                Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == currentspieltag.ToString()).Where(st => st.Saison == Ligamanager.Components.Globals.currentSaison).ToList();
                Spieltage = Spieltage.OrderBy(o => o.Datum);
                for (int i = 0; i < Spieltage.Count(); i++)
                {
                    var columns = Spieltage.ElementAt(i);
                    columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                    columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
                }
            }
            catch (Exception ex )
            {

                Debug.Print(ex.Message);
            }
        }

        public async Task SpieltagChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                currentspieltag = Convert.ToInt32(e.Value);
                Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == currentspieltag.ToString()).Where(st => st.Saison == Ligamanager.Components.Globals.currentSaison).ToList();
                for (int i = 0; i < Spieltage.Count(); i++)
                {
                    var columns = Spieltage.ElementAt(i);
                    columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                    columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
                }

                if (Spieltage.Count() == 0)
                {

                }
            }
        }
        public async Task SpieltagZurueck()
        {
            if (currentspieltag > 1)
                currentspieltag = currentspieltag - 1;
            else
                return;

            Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == currentspieltag.ToString()).Where(st => st.Saison == Ligamanager.Components.Globals.currentSaison).ToList();
            for (int i = 0; i < Spieltage.Count(); i++)
            {
                var columns = Spieltage.ElementAt(i);
                columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
            }
        }

        public async Task SpieltagVor()
        {
            //ToDo AktMaxspieltag
            if (currentspieltag < 34)
                currentspieltag = currentspieltag + 1;
            else
                return;

            Spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == currentspieltag.ToString()).Where(st => st.Saison == Ligamanager.Components.Globals.currentSaison).ToList();
            for (int i = 0; i < Spieltage.Count(); i++)
            {
                var columns = Spieltage.ElementAt(i);
                columns.Verein1 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein1_Nr)).Vereinsname1;
                columns.Verein2 = Vereine.FirstOrDefault(a => a.VereinNr == Convert.ToInt32(columns.Verein2_Nr)).Vereinsname2;
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
