using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeNovel.Models
{
    public class FStory
    {
        public int Id { get; set; }
        public int LastId { get; set; }
        public string StoryTitle { get; set; }
        public string ChapterTitle { get; set; }
        public string ChapterContent { get; set; }
        public string ChapterEncyclopedia { get; set; }
        public int LastChapterId { get; set; }
    }
}
