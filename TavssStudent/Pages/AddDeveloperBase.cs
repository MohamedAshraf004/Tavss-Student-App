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
    public class AddDeveloperBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Parameter]
        public string ProjectId { get; set; }

        public Developer Developer { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Developer = new Developer();
        }
        protected async Task HandleValidSubmit()
        {

            await ProjectService.AddDeveloperToProject(ProjectId, Developer);
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}");

        }
    }
}
