using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Interfaces
{
    public class DateInformation
    {
        public DateInformation()
        {
            CreatedDate = DateTime.Now;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
