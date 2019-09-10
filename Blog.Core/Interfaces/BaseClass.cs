using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Interfaces
{
    public class BaseClass : DateInformation, IEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
