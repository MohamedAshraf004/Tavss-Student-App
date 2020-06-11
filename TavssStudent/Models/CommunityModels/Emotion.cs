using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public enum EmotionType
    {
        Like , Happy , Love , Angry , Wow, DisLike
    }
    public class Emotion
    {
        public string Id { get; set; }
        public EmotionType EType { get; set; }

    }
}
