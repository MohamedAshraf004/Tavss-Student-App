using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Components
{
    public class AddPostDialogBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService { get; set; }
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        [Parameter]
        public string CommunityId { get; set; }
        public string CommunityIdSave { get; set; }

        public InsertPostViewModel Post { get; set; } = new InsertPostViewModel();

        public bool ShowDialog { get; set; }
        public List<Developer> Developers { get; set; }

        public Developer Developer { get; set; }
        public string DeveloperId { get; set; }

        protected override void OnInitialized()
        {
            LoadDeveloper();
            Post.IssuerId = Developers.FirstOrDefault().Id;
            

        }
        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void CloseDialog()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        private void ResetDialog()
        {
            Post = new InsertPostViewModel();
        }
        protected async Task HandleValidSubmit()
        {
            await CommunityService.CreatePost(CommunityIdSave, Post);
            await CloseEventCallback.InvokeAsync(true);
            ShowDialog = false;
            StateHasChanged();
        }

        private void LoadDeveloper()
        {
            Developers = new List<Developer>()
            {
                new Developer()
                {
                     Id="mohamed",
                     Name="Mohamed"
                },
                new Developer()
                {
                     Id="ahmed",
                     Name="Ahmed"
                }
            };
        }

    }
}
