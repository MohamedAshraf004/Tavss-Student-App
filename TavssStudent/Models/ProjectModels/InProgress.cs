
using System;
using System.ComponentModel.DataAnnotations;

namespace TavssStudent.Models
{
    public class InProgress
    {
     
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descreption { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}