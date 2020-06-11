using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string SubscriperId { get; set; }
        public string CommentText { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; } = DateTime.Now;

    }
}
