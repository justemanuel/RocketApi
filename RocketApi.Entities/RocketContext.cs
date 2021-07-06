using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RocketApi.Entities.Models;

namespace RocketApi.Entities
{
    public class RocketContext : IdentityDbContext
    {
        public RocketContext(DbContextOptions<RocketContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();

            modelBuilder.Entity<Owner>(e =>
            {
                e.ToTable("Owner");

                e.Property(e => e.Name).HasMaxLength(50);
                e.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Blog>(e =>
            {
                e.ToTable("Blog");

                e.Property(e => e.Name).HasMaxLength(25);
                e.HasOne(e => e.Owner)
                .WithMany(o => o.Blogs)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Owner_Blog");
            });

            modelBuilder.Entity<Post>(e =>
            {
                e.ToTable("Post");

                e.Property(e => e.Title).HasMaxLength(15);

                e.HasOne(e => e.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_Post");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
