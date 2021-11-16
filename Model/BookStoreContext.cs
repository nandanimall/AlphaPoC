using Microsoft.EntityFrameworkCore;

namespace NetCoreODAT_api.Model
{
    /*   public class BookStoreContext : DbContext
       {
           public BookStoreContext(DbContextOptions<BookStoreContext> options)
               : base(options)
           {
           }

           public DbSet<Book> Books { get; set; }
           public DbSet<Press> Presses { get; set; }

           protected override void OnModelCreating(ModelBuilder modelBuilder)
           {
               modelBuilder.Entity<Book>().OwnsOne(c => c.Location);
           }
       }*/

    public class HiveOdataContext : DbContext
    {
        public HiveOdataContext(DbContextOptions<HiveOdataContext> options)
               : base(options)
        {
        }

        
        public DbSet<HiveDataModel> students1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HiveDataModel>().OwnsOne(c => c.address);
        }
    }

}
