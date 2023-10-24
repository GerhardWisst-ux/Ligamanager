using LigaManagerManagement.Models;
using LigaManagerManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamanagerManagement.Web.Pages
{
    public class SpieltagDetailsBase : ComponentBase
    {
        public Spieltag Spieltag { get; set; } = new Spieltag();
        protected string Coordinates { get; set; }
        protected string ButtonText { get; set; } = "Verberge Footer";
        protected string CssClass { get; set; } = null;

        [Inject]
        public ISpieltagService SpieltagService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Spieltag = await SpieltagService.GetSpieltag(int.Parse(Id));
        }

        protected void Button_Click()
        {
            if (ButtonText == "Verberge Footer")
            {
                ButtonText = "Zeige Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Verberge Footer";
            }
        }

        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
        //}
    }
}
