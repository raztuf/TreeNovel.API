using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Genre
    {
        public int ChapterId { get; set; }
        public string ChapterTitle { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
