using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.ViewModels;

namespace TavssStudent.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectById(string projectId);
        Task<IEnumerable<Project>> GetProjectByName(string projectName);
        Task<Framework> GetFramework(string projectId);
        Task<List<Developer>> GetDevelopersInProject(string projectId);
        Task<Developer> GetDeveloperById(string developerId, string projectId);
        Task<string> GetWiki(string projectId);
        Task<string> DownloadProject(string projectId);
        Task<List<ToDo>> GetAllToDo(string projectId);
        Task<List<InProgress>> GetAllInProgress(string projectId);
        Task<List<Done>> GetAllDone(string projectId);

        //create
        Task CreateProject(CreateProjectViewModel model);
        Task CreateFramework(string projectId);
        Task AddDeveloperToProject(string projectId, Developer developer);
        Task<bool> AddSuperVisorToProject(string projectId, SuperVisor superVisor);
        Task<bool> UploadProject(string projectId, IFileListEntry files);

        //Put
        Task<bool> AssignToDo(string projectId, ToDoViewModel model);
        Task<bool> AssignDone(string projectId, DoneViewModel model);
        Task<bool> AssignInProgress(string projectId, InProgressViewModel model);

        //delete
        Task<bool> RemoveDeveloperFromProject(string projectId, string developerId);
        Task<bool> RemoveToDOFromProject(string projectId, string todoId);
        Task<bool> RemoveInProgressFromProject(string projectId, string inprogressId);
        Task<bool> RemoveDoneFromProject(string projectId, string doneId);
    }
}
