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
    public class ModuleDetailsBase:ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string CourseId { get; set; }
        public CourseDto Course { get; set; } = new CourseDto()
        {
            Doctors=new List<Doctor>(),
            Modules=new List<Module>(),
            Students=new List<Student>()
        };

        [Parameter]
        public string ModeuleId { get; set; }
        public Module Module { get; set; } = new Module()
        {
            Topics=new List<Topic>()
        };
        public string[] Logo { get; set; }
        public string[] TopicPath { get; set; }
        public string[] VideoPath { get; set; }
        public string Localhost { get; set; } = SD.CourseLocalhost;

        protected async override Task OnInitializedAsync()
        {
            var values = Enum.GetNames(typeof(TopicType));
            //var topicType = Enum.GetName(typeof(TopicType), Topic.Type);
            Module = await CourseService.GetModuleById(CourseId, ModeuleId);
            if (Module.Topics !=null&& Module.Topics.Count != 0)
            {
                if(Module.Topics.Any(d=>d.Type.ToString() == values[2]))
                    TopicPath = Module.Topics.FirstOrDefault(d => d.Type.ToString() == values[2]).Path.Split("wwwroot");
                if (Module.Topics.Any(d => d.Type.ToString() == values[0]))
                    VideoPath = Module.Topics.FirstOrDefault(d => d.Type.ToString() == values[0]).Path.Split("wwwroot");
            }
            Course = await CourseService.GetCourseById(CourseId);
        }
        protected void HandleClick(string moduleId)
        {
            NavigationManager.NavigateTo($"/moduledetails/{CourseId}/{moduleId}",true);
        }
    }
}
