using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Models
{
    public class ChapterToDal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int LastChapterId { get; set; }
        public string Encyclopedia { get; set; }
        public string CategoryName { get; set; }
    }
}
