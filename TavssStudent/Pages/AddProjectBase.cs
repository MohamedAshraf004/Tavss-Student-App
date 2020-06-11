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
    public class AddProjectBase:ComponentBase
    {
     [Inject]
        public IProjectService ProjectService{ get; set; }
        public CreateProjectViewModel Project{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            Project = new CreateProjectViewModel()
            {
                Name = string.Empty
            };
        }

        protected async Task HandleValidSubmit()
        {
            await ProjectService.CreateProject(Project);
            NavigationManager.NavigateTo("/projects");

        }
    }
}
