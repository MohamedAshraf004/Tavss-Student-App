using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Services;
using TavssStudent.ViewModels;

namespace TavssStudent.Pages
{
    public class AddInProgressBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Parameter]
        public string ProjectId { get; set; }

        public InProgressViewModel InProgress { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            InProgress = new InProgressViewModel { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        }
        protected async Task HandleValidSubmit()
        {
            await ProjectService.AssignInProgress(ProjectId, InProgress);
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}");

        }
    }
}
