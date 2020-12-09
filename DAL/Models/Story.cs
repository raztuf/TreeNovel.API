using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ChapterId { get; set; }
    }
}
