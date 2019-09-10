using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.UI.Models
{
    public class SubjectofCommentsDTO
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }
    }
}
