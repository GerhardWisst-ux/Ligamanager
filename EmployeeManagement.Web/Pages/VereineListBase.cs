using LigamanagerManagement.Web.Services.Contracts;
using LigaManagerManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Web.Pages
{
    public class VereineListBase : ComponentBase
    {
        [Inject]
        public IVereineService VereineService { get; set; }

        public IEnumerable<Verein> Vereine { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Vereine = (await VereineService.GetVereine()).ToList();
        }

        protected async Task VereinDeleted()
        {
            Vereine = (await VereineService.GetVereine()).ToList();
        }
    }
}
