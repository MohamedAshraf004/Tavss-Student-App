using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TavssStudent.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the StudentUser class
    public class StudentUser : IdentityUser
    {
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public String Phone { get; set; }
        [Display(Name ="Full Name")]
        public String FullName { get; set; }  
    }
}
