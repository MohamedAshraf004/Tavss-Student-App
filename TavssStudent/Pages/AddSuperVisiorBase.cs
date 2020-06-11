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
    public class AddSuperVisiorBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Parameter]
        public string ProjectId { get; set; }

        public SuperVisor SuperVisor { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            SuperVisor = new SuperVisor();
        }
        protected async Task HandleValidSubmit()
        {

            await ProjectService.AddSuperVisorToProject(ProjectId, SuperVisor);
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}");

        }
    }
}
