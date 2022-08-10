using Microsoft.EntityFrameworkCore;

namespace E_AuctionProject.Models
{
    public class AuctionContext:DbContext
    {
        public AuctionContext()
        {
                
        }
        public AuctionContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connect"));
        }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<AddProduct> AddProducts { get; set; }
        public DbSet<ApplyBid> ApplyBids { get; set; }

    }
}
