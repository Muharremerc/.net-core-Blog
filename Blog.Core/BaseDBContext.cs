using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
public static class BaseDBContext<DBContext> where DBContext:DbContext ,new()
    {
        private static DBContext dBContext;

        public static DBContext getInstance()
        {
            if (dBContext == null)
                dBContext = new DBContext();
            return dBContext;
        }
    }
}
