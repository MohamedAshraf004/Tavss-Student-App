using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavssStudent.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required]
        public string Name { get; set; }

    }
}
