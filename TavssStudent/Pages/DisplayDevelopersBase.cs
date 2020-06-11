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
    public class DisplayDevelopersBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService { get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public IEnumerable<Developer> Developers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var community= await CommunityService.GetCommunity(CommunityId);
            Developers = community.Developers;
        }
    }
}
