using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.ViewModels;

namespace TavssStudent.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient httpClient;

        public ProjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task AddDeveloperToProject(string projectId, Developer developer)
        {
            await httpClient.PutJsonAsync<Developer>($"api/MongoProject/api/v1/project/AddDeveloperToProject/{projectId}", developer);
            
        }
        public async Task<bool> AddSuperVisorToProject(string projectId, SuperVisor model)
        {
            var SuperVisorName = model.Name;
            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/AddSuperVisorToProject/{projectId}/{SuperVisorName}", null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AssignDone(string projectId, DoneViewModel model)
        {
            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/AssignDone/{projectId}", modelJson);
            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<DoneViewModel>(await response.Content.ReadAsStreamAsync());
                return true;
            }
            return false;
        }

        public async Task<bool> AssignInProgress(string projectId, InProgressViewModel model)
        {
           
            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/Inprogress/{projectId}", modelJson);
            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<InProgressViewModel>(await response.Content.ReadAsStreamAsync());
                return true;
            }
            return false;
        }

        public async Task<bool> AssignToDo(string projectId, ToDoViewModel model)
        {

            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/AssignToDo/{projectId}", modelJson);
            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<ToDoViewModel>(await response.Content.ReadAsStreamAsync());
                return true;
            }
            return false;
        }

        public async Task CreateFramework(string projectId)
        {
            await httpClient.PostJsonAsync($"api/MongoProject/api/v1/project/CreateFramework/{projectId}", null);


        }

        public async Task CreateProject(CreateProjectViewModel model)
        {
            //var r = await httpClient.PostJsonAsync<CreateProjectViewModel>($"api/MongoProject/api/v1/project/CreateProject",model);

            StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/MongoProject/api/v1/project/CreateProject", modelJson);
            if (response.IsSuccessStatusCode)
            {
                var result = await JsonSerializer.DeserializeAsync<CreateProjectViewModel>(await response.Content.ReadAsStreamAsync());
                return;
            }
        }

        public async Task<string> DownloadProject(string projectId)
        {
            return await httpClient.GetJsonAsync<String>($"api/MongoProject/api/v1/project/DownloadProject/{projectId}");

        }

        public async Task<List<Done>> GetAllDone(string projectId)
        {
            return await httpClient.GetJsonAsync<List<Done>>($"api/v1/project/{projectId}");

        }

        public async Task<List<InProgress>> GetAllInProgress(string projectId)
        {
            return await httpClient.GetJsonAsync<List<InProgress>>($"api/v1/project/{projectId}");

        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await httpClient.GetJsonAsync<List<Project>>($"api/MongoProject/api/v1/project/GetAllProjects");

            //return await JsonSerializer.DeserializeAsync<IEnumerable<Project>>
            //(await httpClient.GetStreamAsync($"api/mongoproject/api/v1/project/getallprojects"),
            //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task<List<ToDo>> GetAllToDo(string projectId)
        {
            return await httpClient.GetJsonAsync<List<ToDo>>($"api/MongoProject/api/v1/project/GetProjectById/{projectId}");

        }

        public async Task<Developer> GetDeveloperById(string developerId, string projectId)
        {
            return await httpClient.GetJsonAsync<Developer>($"api/v1/project/{developerId}/{projectId}");

        }

        public async Task<List<Developer>> GetDevelopersInProject(string projectId)
        {
            return await httpClient.GetJsonAsync<List<Developer>>($"api/v1/project/{projectId}");

        }

        public async Task<Framework> GetFramework(string projectId)
        {
            var r= await httpClient.GetJsonAsync<Framework>($"api/MongoProject/api/v1/project/GetFramework/{projectId}");
            return r;
        }

        public async Task<Project> GetProjectById(string projectId)
        {
            //var r= await httpClient.GetJsonAsync<Project>($"api/MongoProject/api/v1/project/GetProjectById/{projectId}");
            //return r;
            return await JsonSerializer.DeserializeAsync<Project>
            (await httpClient.GetStreamAsync($"api/MongoProject/api/v1/project/GetProjectById/{projectId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Project>> GetProjectByName(string projectName)
        {
            return await httpClient.GetJsonAsync<IEnumerable<Project>>($"api/v1/project/{projectName}");

        }

        public async Task<string> GetWiki(string projectId)
        {
            return await httpClient.GetJsonAsync<string>($"api/MongoProject/api/v1/project/WriteWiki/{projectId}");

        }


        #region Delete
        public async Task<bool> RemoveProject(string projectId)
        {
            await httpClient.DeleteAsync($"api/MongoProject/api/v1/project/RemoveProjectById/{projectId}");
            return true;
        }
        public async Task<bool> RemoveDeveloperFromProject(string projectId, string developerId)
        {
            await httpClient.DeleteAsync($"api/MongoProject/api/v1/project/RemoveDeveloperFromProject/{projectId}/{developerId}");
            return true;
        }
        public async Task<bool> RemoveToDOFromProject(string projectId, string todoId)
        {
            await httpClient.DeleteAsync($"api/MongoProject/api/v1/project/RemoveToDoFromProject/{projectId}/{todoId}");
            return true;
        }
        public async Task<bool> RemoveInProgressFromProject(string projectId, string inprogressId)
        {
            await httpClient.DeleteAsync($"api/MongoProject/api/v1/project/RemoveInProgressFromProject/{projectId}/{inprogressId}");
            return true;
        }
        public async Task<bool> RemoveDoneFromProject(string projectId, string doneId)
        {
            await httpClient.DeleteAsync($"api/MongoProject/api/v1/project/RemoveDoneFromProject/{projectId}/{doneId}");
            return true;
        }

        public async Task<bool> UploadProject(string projectId, IFileListEntry files)
        {
            //await httpClient.PutJsonAsync<Developer>($"api/MongoProject/api/v1/project/UploadProject/{projectId}", project);

            //StringContent modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            //var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/AddSuperVisorToProject/{projectId}/{SuperVisorName}", null);
            //if (response.IsSuccessStatusCode)
            //{
            //    return true;
            //}
            //return false;
            var file = files;
            if (file != null)
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);
                var content = new MultipartFormDataContent {
                { new ByteArrayContent(ms.GetBuffer()), "\"upload\"", file.Name }};
                var response = await httpClient.PutAsync($"api/MongoProject/api/v1/project/UploadProject/{projectId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
                return false;

        }

        #endregion
    }
}
