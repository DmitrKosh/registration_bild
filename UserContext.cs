using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace registration
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DataBase")
            { }
        public DbSet<Users> Users { get; set; }


    }
}
