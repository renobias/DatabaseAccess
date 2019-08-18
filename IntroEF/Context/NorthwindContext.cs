using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IntroEF.Entity;

namespace IntroEF.Context
{
    class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("NORTHWIND") { }
        public virtual DbSet<Customers>Customers{get;set;}
    }
}
