using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class IndesBase:ComponentBase
    {
        [Inject]
        public IProjectService ProjectService{ get; set; }
        [Inject]
        public ICourseService CourseService{ get; set; }
        [Inject]
        public ICommunityService CommunityService{ get; set; }

        public HomeViewModel HomeViewModel { get; set; } = new HomeViewModel()
        {
            Courses = new List<MinCourseViewModel>(),
            Communities = new List<MinCommunityListViewModel>(),
            Projects = new List<Project>()
        };
        public string[] Logo { get; set; }
        public string[] ProjectPath { get; set; }
        public string ProjectLocalhost { get; set; } = SD.ProjectLocalhost;
        public string CommunityLocalhost { get; set; } = SD.CommunityLocalhost;
        public string CourseLocalhost { get; set; } = SD.CourseLocalhost;

        protected async override Task OnInitializedAsync()
        {
            HomeViewModel.Projects = await ProjectService.GetAllProjects();
            HomeViewModel.Communities = await CommunityService.GetCommunities();
            HomeViewModel.Courses = await CourseService.GetCourses();
        }

    }
}
