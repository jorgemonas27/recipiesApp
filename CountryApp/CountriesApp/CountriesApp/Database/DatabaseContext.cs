using CountriesApp.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace CountriesApp.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
    
}
