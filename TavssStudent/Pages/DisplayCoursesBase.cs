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
    public class DisplayCoursesBase:ComponentBase
    {
        [Inject]
        public ICourseService CourseService{ get; set; }

        public IEnumerable<MinCourseViewModel> Courses{ get; set; }
        //public IEnumerable<Doctor> Doctors{ get; set; }

        public string[] Logo { get; set; }
        public string[] Path { get; set; }
        public string Localhost { get; set; } = SD.CourseLocalhost;
        protected async override Task OnInitializedAsync()
        {
            Courses = await CourseService.GetCourses();
            //Doctors= (await CourseService.GetDotorsForCourse(course.Id)).ToList()
        }
    }
}
