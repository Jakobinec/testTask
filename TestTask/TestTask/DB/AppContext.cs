using System.Data.Entity;
using TestTask.Models;

namespace TestTask.DB
{
    /// <summary>
    /// Class to connect with datebase
    /// </summary>
    public class AppContext: DbContext
    {
        public AppContext()
            : base("ConnectionString")
                { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Driver> Drivers { get; set; }
    }
}