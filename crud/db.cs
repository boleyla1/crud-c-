using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crud
{
    public class db : DbContext
    {
        public db() : base("rt")
        {

        }
        public DbSet<human> human { get; set; }
    }
}
