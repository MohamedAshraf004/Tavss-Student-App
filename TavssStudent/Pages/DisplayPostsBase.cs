using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Components;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class DisplayPostsBase : ComponentBase
    {

        [Inject]
        public ICommunityService CommunityService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public IEnumerable<Post> AllPosts { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public int PostsCount { get; set; }
        public List<Developer> Developers { get; set; }

        public Developer Developer { get; set; }
        public CommunitiesDto Community { get; set; }

        public string[] Logo { get; set; }
        public string[] Path { get; set; }
        public string Localhost { get; set; } = SD.CommunityLocalhost;
        public int PageCount { get; set; }
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 9;
        public string Title { get; set; }

        protected async override Task OnInitializedAsync()
        {
            LoadDeveloper();
            Community = await CommunityService.GetCommunity(CommunityId);
            AllPosts = Community.Posts.OrderByDescending(d => d.Time);
            Title = Community.Name + " Posts";
            if (AllPosts == null || AllPosts.Count() == 0)
            {
                AllPosts = (await CommunityService.GetAllPosts()).ToList().OrderByDescending(d => d.Time);
                Title = "All Posts";
            }
            PostsCount = AllPosts.Count();
            PageCount = PostsCount / 9;
            Posts = AllPosts.Skip(PageNumber * PageSize).Take(PageSize);
        }
        protected void IncreasePage()
        {
            PageNumber = ++PageNumber;
            if (PageNumber > PageCount)
            {
                Posts = Posts;
            }
            else
            {
                //Posts = await CommunityService.GetAllPosts();
                Posts = AllPosts.Skip(PageNumber * PageSize).OrderByDescending(d => d.Time).Take(PageSize);
                StateHasChanged();
                NavigationManager.NavigateTo($"/posts/{CommunityId}");
            }

        }
        protected void DecreasePage()
        {
            PageNumber = --PageNumber;
            if (PageNumber < 0)
            {
                Posts = Posts;
            }
            else
            {
                //Posts = await CommunityService.GetAllPosts();
                Posts = AllPosts.Skip(PageNumber * PageSize).OrderByDescending(d => d.Time).Take(PageSize);
                StateHasChanged();
                NavigationManager.NavigateTo($"/posts/{CommunityId}");
            }
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

        public AddPostDialogBase AddPostDialog { get; set; }
        protected void QuickAddPost()
        {
            AddPostDialog.Show();
        }
        public async void AddPostDialog_OnDialogClose()
        {
            LoadDeveloper();
            AllPosts = (await CommunityService.GetAllPosts()).ToList().OrderBy(d => d.Time);
            PostsCount = AllPosts.Count();
            PageCount = PostsCount / 9;
            Posts = AllPosts.Skip(PageNumber * PageSize).Take(PageSize);
            StateHasChanged();
        }
        protected void SaveId()
        {
            CommunityId = CommunityId;
        }
    }
}
