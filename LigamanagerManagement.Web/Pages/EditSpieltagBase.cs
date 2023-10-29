using AutoMapper;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SpieltagManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class EditSpieltagBase : ComponentBase
    {
        public Int32 currentspieltag = 1;

        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        public string PageHeaderText { get; set; }

        public IEnumerable<Spieltag> spieltage { get; set; }

        public EditSpieltagModel EditSpieltagModel { get; set; } =
            new EditSpieltagModel();

        public List<DisplaySpieltag> SpieltagList;

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }
                    
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
               
        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if(!authenticationState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/editSpieltag/{Id}");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            }

            SpieltagList = new List<DisplaySpieltag>();

            for (int i = 1; i < 34; i++)
            {
                SpieltagList.Add(new DisplaySpieltag(i.ToString(), i.ToString() + ".Spieltag"));
            }


        }

        public async Task SpieltagChange(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                currentspieltag = Convert.ToInt32(e.Value);
                spieltage = (await SpieltagService.GetSpieltage()).Where(st => st.SpieltagNr == currentspieltag.ToString()).Where(st => st.Saison == Ligamanager.Components.Globals.currentSaison).ToList();
                
            }
        }

        protected Ligamanager.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
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
