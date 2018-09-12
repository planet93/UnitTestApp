using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UnitTestApp.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}