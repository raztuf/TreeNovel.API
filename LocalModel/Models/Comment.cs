﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public User Writer { get; set; }
        public int ChapterId { get; set; }
    }
}
