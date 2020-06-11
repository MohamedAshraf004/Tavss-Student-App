using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public enum IssuerType
    {
        Developer , Organization , Company
    }
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            Emotions = new List<Emotion>();
        }
        public string Id { get; set; }
        public IssuerType IssuerType { get; set; }
        public string IssuerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Emotion> Emotions { get; set; }

    }
}
