using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ChapterId { get; set; }
    }
}
