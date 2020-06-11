
using System.Collections.Generic;


namespace TavssStudent.Models
{
    public class Framework
    {
        public Framework()
        {
            Dones = new List<Done>() { };
            ToDos = new List<ToDo>() { };
            InProgress = new List<InProgress>() { };
        }
        public string Id { get; set; }
        public List<Done> Dones { get; set; }

        public List<ToDo> ToDos { get; set; }

        public List<InProgress> InProgress { get; set; }

    }
}