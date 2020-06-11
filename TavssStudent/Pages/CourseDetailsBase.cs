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
    public class CourseDetailsBase:ComponentBase
    {
        [Inject]
        public ICourseService CourseService{ get; set; }

        public CourseDto Course { get; set; } = new CourseDto()
        {
            Modules = new List<Module>()
        };

        [Parameter]
        public string CourseId { get; set; }

        public string[] Logo { get; set; }
        public string[] Path { get; set; }
        public string Localhost { get; set; } = SD.CourseLocalhost;

        protected async override Task OnInitializedAsync()
        {
            Course = await CourseService.GetCourseById(CourseId);
        }
    }
}
