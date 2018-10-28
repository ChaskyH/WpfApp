using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.DataProtocol;

namespace WpfApp.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() :base()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Goals> Goals { get; set; }
    }
}
