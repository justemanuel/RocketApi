using System;
using Microsoft.EntityFrameworkCore;

namespace RocketApi.Entities.Models
{
    public class PgContext : DbContext
    {
        public PgContext(DbContextOptions<PgContext> options): base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Entity>();

            builder.Entity<Owner>(e =>
            {
                e.Property(e => e.Name).HasMaxLength(25);
                e.Property(e => e.LastName).HasMaxLength(25);

            });

            builder.Entity<Blog>(e =>
            {
                e.Property(e => e.Name).HasMaxLength(50);

                e.HasOne(e => e.Owner)
                .WithMany(o => o.Blogs)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Post>(e =>
            {
                e.HasOne(e => e.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(builder);
        }
    }
}
