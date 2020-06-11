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
    public class TopicDetailsBase:ComponentBase
    {
        [Inject]
        public ICourseService CourseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string CourseId { get; set; }
        [Parameter]
        public string ModeuleId { get; set; }
        [Parameter]
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public string[] Logo { get; set; }
        public string[] TopicPath { get; set; }
        public string Localhost { get; set; } = SD.CourseLocalhost;

        protected async override Task OnInitializedAsync()
        {
            Topic = await CourseService.GetTopicById(CourseId, ModeuleId,TopicId);
            if (Topic != null && Topic.Path != null)
            {
                TopicPath = Topic.Path.Split("wwwroot");
            }
            Topics = (await CourseService.GetModuleById(CourseId, ModeuleId)).Topics.Where(t=>t.Id!=TopicId);
            
        }
        protected void HandleClick(string moduleId)
        {
            NavigationManager.NavigateTo($"/moduledetails/{CourseId}/{moduleId}", true);
        }
        protected void HandleClickTopic(string CourseId, string ModeuleId, string TopicId)
        {
            NavigationManager.NavigateTo($"/topicdetails/{CourseId}/{ModeuleId}/{TopicId}", true);
        }
    }
}
