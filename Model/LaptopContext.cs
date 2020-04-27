using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NetWebApi.Model;

namespace ASP.NetWebApi.Model
{
    public class LaptopContext : DbContext
    {
        public LaptopContext(DbContextOptions<LaptopContext> opt) : base(opt)
        {

        }
       public DbSet<Laptop> Laptops { get; set; }
    }
}
