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
    public class DisplayCommunitiesBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService { get; set; }

        public string[] Logo { get; set; }
        public string Localhost { get; set; } = SD.CommunityLocalhost;

        public IEnumerable<MinCommunityListViewModel> Communties{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Communties = await CommunityService.GetCommunities();
        }

    }
}
