﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Models
{
    public class DiscussionToDal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int ReplyToId { get; set; }
        public int UserId { get; set; }
    }
}
