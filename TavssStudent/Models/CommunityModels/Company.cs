using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class Company 
    {
        public Company()
        {
            Contacts = new List<string>();
        }
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
        public List<string> Contacts { get; set; }
    }
}
