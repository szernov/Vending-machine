using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
 public   class Context:DbContext
    {
        public DbSet<Vm> vm { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<SellStatistic> sellst { get; set; }
        public DbSet<AmountOfProducts> allst { get; set; }

        public Context() : base("VmDataBAses")
        {

        }
    }
}

