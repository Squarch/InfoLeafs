using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoLeafs.Models
{
    public class PostViewModel
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}