using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RocketApi.Entities.Models;
using System;

namespace RocketApi.Entities
{
    public class RocketContext : IdentityDbContext<ApplicationUser>
    {
        public RocketContext(DbContextOptions<RocketContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public new virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Status> Status { get; set; }

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

            modelBuilder.Entity<Status>(e =>
            {
                e.ToTable("Status");

                e.Property(e => e.Content).HasMaxLength(280);

                e.Property(e => e.Created).HasDefaultValue(DateTime.UtcNow);

                e.HasOne(e => e.User)
                .WithMany(u => u.Status)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_User_Status");
            });

            modelBuilder.Entity<Follow>()                                            //  1.
                .HasKey(k => new { k.FollowerId, k.FolloweeId });

            modelBuilder.Entity<Follow>()                                            //  2.
                .HasOne(u => u.Followee)
                .WithMany(u => u.Follower)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()                                            //  3.
                .HasOne(u => u.Follower)
                .WithMany(u => u.Followee)
                .HasForeignKey(u => u.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
