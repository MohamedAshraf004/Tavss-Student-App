using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;

namespace TavssStudent.Services
{
    public interface ICommunityService
    {
        Task<IEnumerable<MinCommunityListViewModel>> GetCommunities();
        Task<CommunitiesDto> GetCommunity(string CID);
        Task<IEnumerable<MinCommunityListViewModel>> GetDeveloperCommunities(string DID);

        //company
        Task<IEnumerable<Company>> GetCompanies();
        Task<IEnumerable<Company>> GetCommunityCompanies(string CID);
        Task<Company> GetCompany(string CoID);
        Task<Company> SearchCompany(string Name);

        #region Posts
        Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<Post>> GetIssuerPosts(string IID);
        Task<Post> GetPost(string PID);
        Task<bool> CreatePost(string CID, InsertPostViewModel model);
        Task<bool> ModifyPost(string CID, string PID, UpdatePostViewModel model);
        Task<bool> ModifyPostImage(string CID, string PID, IFormFile file);
        Task<bool> DeletePost(string CID, string PID);
        Task<bool> Emo(string CID, string PID, Emotion emotion);
        Task<bool> DeEmo(string CID, string PID, string EID);
        #endregion
    }
}
