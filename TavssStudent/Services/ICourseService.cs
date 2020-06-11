using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;

namespace TavssStudent.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<MinCourseViewModel>> GetCourses();
        Task<IEnumerable<MinCourseViewModel>> GetCoursesForStudent(string SID);
        Task<IEnumerable<Doctor>> GetDotorsForCourse(string CID);
        Task<CourseDto> GetCourseById(string CID);
        Task<Module> GetModuleById(string CID, string MID);
        Task<Topic> GetTopicById(string CID, string MID, string TID);
    }
}
