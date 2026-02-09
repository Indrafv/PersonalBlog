using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;
namespace PersonalBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Articles> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(tb =>
            {
                tb.HasKey(col => col.IdUser);
                tb.Property(col => col.IdUser)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
                tb.Property(col => col.name).HasMaxLength(50);
                tb.Property(col => col.password).HasMaxLength(255);
            });
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Articles>(tb =>
            {
                tb.HasKey(col => col.ArticleId);
                tb.Property(col => col.PublishingDate).HasDefaultValueSql("GETUTCDATE()");
                tb.Property(col => col.Title).HasMaxLength(50);
                tb.Property(col => col.Content).HasMaxLength(2000);

            });
            modelBuilder.Entity<Articles>().ToTable("Articles");
        }
    }
}
