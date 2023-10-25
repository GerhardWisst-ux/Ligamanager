using AutoMapper;
using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SpieltagManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class EditSpieltagBase : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        public string PageHeaderText { get; set; }

        private Spieltag spieltag { get; set; } = new Spieltag();

        public EditSpieltagModel EditSpieltagModel { get; set; } =
            new EditSpieltagModel();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Verein> Vereine { get; set; } =
            new List<Verein>();

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

            int.TryParse(Id, out int spieltagId);

            if (spieltagId != 0)
            {
                PageHeaderText = "Bearbeiten Spieltag";
                spieltag = await SpieltagService.GetSpieltag(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Neuer Spieltag";
                spieltag = new Spieltag
                {
                    Verein1_Nr = "16",
                    Verein2_Nr = "5",
                    Tore1_Nr = 5,
                    Tore2_Nr = 0,
                    Datum = DateTime.Now,
                    Ort = "MHP-Arena",
                };
            }

            //Departments = (await DepartmentService.GetDepartments()).ToList();
            //Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {
            //Todo
            //Mapper.Map(EditEmployeeModel, Spieltag);

            //Employee result = null;

            //if (spieltag != 0)
            //{
            //    result = await SpieltagService.UpdateSpieltag(Spieltag);
            //}
            //else
            //{
            //    result = await SpieltagService.CreateEmployee(Employee);
            //}
            //if (result != null)
            //{
            //    NavigationManager.NavigateTo("/");
            //}
        }

        protected PragimTech.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await SpieltagService.DeleteSpieltag(spieltag.SpieltagId);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
