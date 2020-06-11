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
    public class ProjectDetailsBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string ProjectId { get; set; }
        public int ToDoDuration { get; set; }
        public int DoneDuration { get; set; }
        public int InProgressDuration { get; set; }
        public int MaxDuration { get; set; }
        public bool ShowDownload { get; set; } = false;
        public string[] Logo { get; set; }
        public string[] Logos { get; set; }
        public string[] ProjectPath { get; set; }
        public string[] WikiPath { get; set; }
        public string ProjectDownloadPath { get; set; }
        public string WikiDownloadPath { get; set; }
        public string Localhost { get; set; } = SD.ProjectLocalhost;

        public Project Project { get; set; } = new Project()
        {
            Developer = new List<Developer>(),
            Framework = new Framework(),
            SuperVisior = new SuperVisor() { Name = "No Doctor yet." }
        };

        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public Framework FrameworkParm { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Project = await ProjectService.GetProjectById(ProjectId);
            if (Project.ProjectLogo != null && Project.ProjectLogo.Contains("wwwroot") )
            {
                Logo = Project.ProjectLogo.Split("wwwroot");
            }
            if (Project.SuperVisior == null)
            {
                Project.SuperVisior = new SuperVisor { Name = "No Doctor yet." };
            }
            FrameworkParm = Project.Framework;
            if (Project.Framework != null && Project.Framework.ToDos != null)
            {
                var maxduration = new List<int>();
                if (Project.Framework.ToDos.Count() > 0)
                {
                    ToDoDuration = (Project.Framework.ToDos.Max(t => t.EndDate) - Project.Framework.ToDos.Min(t => t.StartDate)).Days;
                    maxduration.Add(ToDoDuration);
                }
                if (Project.Framework.InProgress.Count() > 0)
                {
                    InProgressDuration = (Project.Framework.InProgress.Max(t => t.EndDate) - Project.Framework.InProgress.Min(t => t.StartDate)).Days;
                    maxduration.Add(InProgressDuration);

                }
                if (Project.Framework.Dones.Count() > 0)
                {
                    DoneDuration = (Project.Framework.Dones.Max(t => t.EndDate) - Project.Framework.Dones.Min(t => t.StartDate)).Days;
                    maxduration.Add(DoneDuration);
                }
                //MaxDuration = maxduration.Max();
                MaxDuration = ToDoDuration+InProgressDuration+DoneDuration;

            }
            Projects = (await ProjectService.GetAllProjects()).ToList().Where(p => p.Id != ProjectId).Take(3);

        }

        protected async Task CreateFrameworkAsync()
        {
            await ProjectService.CreateFramework(ProjectId);
            Project = await ProjectService.GetProjectById(ProjectId);
            FrameworkParm = Project.Framework;
            if (Project.ProjectLogo != null && Project.ProjectLogo.Contains("wwwroot"))
            {
                Logo = Project.ProjectLogo.Split("wwwroot");
            }
            if (Project.SuperVisior == null)
            {
                Project.SuperVisior = new SuperVisor { Name = "No Doctor yet." };
            }
            //if (Project.Framework != null && Project.Framework.ToDos != null)
            //{
            //    var maxduration = new List<int>();
            //    if (Project.Framework.ToDos.Count() > 0)
            //    {
            //        ToDoDuration = Project.Framework.ToDos.Max(t => t.EndDate).Day - Project.Framework.ToDos.Min(t => t.StartDate).Day;
            //        maxduration.Add(ToDoDuration);
            //    }
            //    if (Project.Framework.InProgress.Count() > 0)
            //    {
            //        InProgressDuration = Project.Framework.InProgress.Max(t => t.EndDate).Day - Project.Framework.InProgress.Min(t => t.StartDate).Day;
            //        maxduration.Add(InProgressDuration);

            //    }
            //    if (Project.Framework.Dones.Count() > 0)
            //    {
            //        DoneDuration = Project.Framework.Dones.Max(t => t.EndDate).Day - Project.Framework.Dones.Min(t => t.StartDate).Day;
            //        maxduration.Add(DoneDuration);
            //    }
            //    MaxDuration = maxduration.Max();
            //}
            Projects =(await ProjectService.GetAllProjects()).ToList().Where(p=>p.Id!=ProjectId).Take(3);
            StateHasChanged();
            //NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);

        }
        protected async Task DeleteDeveloperAsync(string developerId)
        {
            await ProjectService.RemoveDeveloperFromProject(ProjectId, developerId);
            StateHasChanged();
            NavigationManager.NavigateTo($"/projectdetails/{ProjectId}", true);
        }
        protected async Task ProjectDeleted()
        {
            Project = await ProjectService.GetProjectById(ProjectId);
            if (Project.SuperVisior == null)
            {
                Project.SuperVisior = new SuperVisor { Name = "No Doctor yet." };
            }
            //FrameworkParm = Project.Framework;
            var result = await ProjectService.GetAllProjects();
            Projects = result.Where(p => p.Id != ProjectId).Take(3);
            //StateHasChanged();
        }
        protected void ProjectDownload()
        {
            ShowDownload = true;
            if (Project.ProjectPath !=null && Project.ProjectPath.Contains("wwwroot"))
            {
                ProjectPath = Project.ProjectPath.Split("wwwroot");
                ProjectDownloadPath = Localhost + ProjectPath[1];
            }
            if (Project.Wiki !=null && Project.Wiki.Contains("wwwroot"))
            {
                WikiPath = Project.Wiki.Split("wwwroot");
                WikiDownloadPath = Localhost + WikiPath[1];
            }
            StateHasChanged();

        }

        protected void HandleClick(string projectId)
        {
            NavigationManager.NavigateTo($"/projectdetails/{projectId}", true);
        }
    }
}
