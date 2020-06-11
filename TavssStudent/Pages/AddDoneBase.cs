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
    public class AddDoneBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Parameter]
        public string ProjectId { get; set; }

        public DoneViewModel Done { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Done = new DoneViewModel { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        }
        protected async Task HandleValidSubmit()
        {
            await ProjectService.AssignDone(ProjectId, Done);
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}");

        }
    }
}
