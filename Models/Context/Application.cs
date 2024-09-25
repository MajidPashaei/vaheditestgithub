using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models.DataBase;

namespace Project.Models.Context
{
    public class Application : DbContext
    {
        public Application(DbContextOptions<Application> options) : base(options) { }
        public DbSet<Tbl_Pay> tbl_pays { get; set; }
    }
}