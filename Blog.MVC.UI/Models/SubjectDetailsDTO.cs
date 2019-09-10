using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.UI.Models
{
    public class SubjectDetailsDTO
    {
        public SubjectDetailsDTO()
        {
            Comment = new List<SubjectofCommentsDTO>();
        }
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creater { get; set; }
        public List<SubjectofCommentsDTO> Comment{ get; set; }
    }
}
