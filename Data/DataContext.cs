using Microsoft.EntityFrameworkCore;
using Movies_API.Entities;

namespace Movies_API.Data
{
    public class DataContext : DbContext
    {

        //comand for datamigration
        //add-migration Movies API
        //update-database –verbose
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

    }
}
