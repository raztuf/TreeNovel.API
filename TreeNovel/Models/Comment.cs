using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeNovel.Models
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
