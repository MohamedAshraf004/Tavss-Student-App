using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class MinCourseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public IEnumerable<string> DRID { get; set; }
    }
}
