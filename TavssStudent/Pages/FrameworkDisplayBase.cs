using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class FrameworkDisplayBase : ComponentBase
    {
        [Parameter]
        public string ProjectId { get; set; }
        [Parameter]
        public Framework FrameworkParm { get; set; }
        [Parameter]
        public int ToDoDuration { get; set; }
        [Parameter]
        public int DoneDuration { get; set; }
        [Parameter]
        public int InProgressDuration { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback<string> OnProjectDeleted { get; set; }
        public Framework Framework { get; set; } = new Framework()
        {
            ToDos = new List<ToDo>(),
            Dones = new List<Done>(),
            InProgress = new List<InProgress>()
        };
        [Inject]
        public IProjectService ProjectService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (ProjectId != null)
            {
                Framework = await ProjectService.GetFramework(ProjectId);
                if (Framework.ToDos.Count() > 0)
                {
                    ToDoDuration = (Framework.ToDos.Max(t => t.EndDate) - Framework.ToDos.Min(t => t.StartDate)).Days;
                }
                if (Framework.InProgress.Count() > 0)
                {
                    InProgressDuration = (Framework.InProgress.Max(t => t.EndDate) - Framework.InProgress.Min(t => t.StartDate)).Days;

                }
                if (Framework.Dones.Count() > 0)
                {
                    DoneDuration = (Framework.Dones.Max(t => t.EndDate) - Framework.Dones.Min(t => t.StartDate)).Days;
                }
            }
        }
        
        protected async Task DeleteToDoAsync(string todoId)
        {
            await ProjectService.RemoveToDOFromProject(ProjectId, todoId);
            if (ProjectId != null)
            {
                Framework = await ProjectService.GetFramework(ProjectId);
                if (Framework.ToDos.Count() > 0)
                {
                    ToDoDuration = (Framework.ToDos.Max(t => t.EndDate) - Framework.ToDos.Min(t => t.StartDate)).Days;
                }
                if (Framework.InProgress.Count() > 0)
                {
                    InProgressDuration = (Framework.InProgress.Max(t => t.EndDate) - Framework.InProgress.Min(t => t.StartDate)).Days;

                }
                if (Framework.Dones.Count() > 0)
                {
                    DoneDuration = (Framework.Dones.Max(t => t.EndDate) - Framework.Dones.Min(t => t.StartDate)).Days;
                }
            }

            await OnProjectDeleted.InvokeAsync(ProjectId);
            StateHasChanged();
            //NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);
        }
        protected async Task DeleteInProgressAsync(string inprogressId)
        {
            await ProjectService.RemoveInProgressFromProject(ProjectId, inprogressId);
            if (ProjectId != null)
            {
                Framework = await ProjectService.GetFramework(ProjectId);
                if (Framework.ToDos.Count() > 0)
                {
                    ToDoDuration = (Framework.ToDos.Max(t => t.EndDate) - Framework.ToDos.Min(t => t.StartDate)).Days;
                }
                if (Framework.InProgress.Count() > 0)
                {
                    InProgressDuration = (Framework.InProgress.Max(t => t.EndDate) - Framework.InProgress.Min(t => t.StartDate)).Days;

                }
                if (Framework.Dones.Count() > 0)
                {
                    DoneDuration = (Framework.Dones.Max(t => t.EndDate) - Framework.Dones.Min(t => t.StartDate)).Days;
                }
            }

            await OnProjectDeleted.InvokeAsync(ProjectId);
            StateHasChanged();
            //NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);
        }
        protected async Task DeleteDoneAsync(string doneId)
        {
            await ProjectService.RemoveDoneFromProject(ProjectId, doneId);
            if (ProjectId != null)
            {
                Framework = await ProjectService.GetFramework(ProjectId);
                if (Framework.ToDos.Count() > 0)
                {
                    ToDoDuration = (Framework.ToDos.Max(t => t.EndDate) - Framework.ToDos.Min(t => t.StartDate)).Days;
                }
                if (Framework.InProgress.Count() > 0)
                {
                    InProgressDuration = (Framework.InProgress.Max(t => t.EndDate) - Framework.InProgress.Min(t => t.StartDate)).Days;

                }
                if (Framework.Dones.Count() > 0)
                {
                    DoneDuration = (Framework.Dones.Max(t => t.EndDate) - Framework.Dones.Min(t => t.StartDate)).Days;
                }
            }

            await OnProjectDeleted.InvokeAsync(ProjectId);
            StateHasChanged();
            //NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);
        }
    }
}
