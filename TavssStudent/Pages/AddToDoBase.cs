using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;
using TavssStudent.ViewModels;

namespace TavssStudent.Pages
{
    public class AddToDoBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService{ get; set; }
        [Parameter]
        public string ProjectId { get; set; }

        public ToDoViewModel ToDo{ get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            ToDo = new ToDoViewModel { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        }
        protected async Task HandleValidSubmit()
        {
            await ProjectService.AssignToDo(ProjectId, ToDo);
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}");

        }

    }
}
