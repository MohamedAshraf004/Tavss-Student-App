using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class DisplayCompaniesBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService{ get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public IEnumerable<Company> Companies{ get; set; }

        public string[] Logo { get; set; }
        public string Localhost { get; set; } = SD.CommunityLocalhost;
        protected override async Task OnInitializedAsync()
        {
            if (CommunityId!=null)
            {
                Companies = await CommunityService.GetCommunityCompanies(CommunityId);
            }
            else
            {
                Companies = await CommunityService.GetCompanies();
            }
        }

    }
}
