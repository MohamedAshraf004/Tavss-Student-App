using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public List<Module> Modules { get; set; } = new List<Module>();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
