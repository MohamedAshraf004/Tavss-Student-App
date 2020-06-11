using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class HomeViewModel
    {

        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<MinCourseViewModel> Courses { get; set; }
        public IEnumerable<MinCommunityListViewModel> Communities { get; set; }

    }
}
