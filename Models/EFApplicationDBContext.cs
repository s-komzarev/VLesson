using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Models
{
    public class EFApplicationDBContext : DbContext 
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection"); // установил соединение
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        
        public EFApplicationDBContext()
        {
            Database.EnsureCreated();
        }

        
        public EFApplicationDBContext(DbContextOptions<EFApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }


    }
}
