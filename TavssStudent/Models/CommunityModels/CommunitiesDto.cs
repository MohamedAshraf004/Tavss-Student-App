using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class CommunitiesDto
    {
        public CommunitiesDto()
        {
            Companies = new List<Company>();
            Developers = new List<Developer>();
            Organizations = new List<Organization>();
            Posts = new List<Post>();
        }  
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public List<Company> Companies { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Post> Posts { get; set; }


    }
}
