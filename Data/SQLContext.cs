using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data
{
    public partial class SQLContext : DbContext
    {
        public SQLContext()
        {
        }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Event> UserEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Created);
                entity.Property(e => e.LastUpdate);
                entity.Property(e => e.Erased);

                entity.HasIndex(e => e.Email)
                    .HasName("AK_User_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("AK_User_Username")
                    .IsUnique();

                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.AccessRole);
            });



            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Created);
                entity.Property(e => e.LastUpdate);
                entity.Property(e => e.Erased);

                entity.Property(e => e.EventName);
                entity.Property(e => e.EventDate);
                entity.Property(e => e.StatusEvent);
            });

            //many to many relationship
            modelBuilder.Entity<UserEvent>()
            .HasKey(t => new { t.UserId, t.EventId });

            modelBuilder.Entity<UserEvent>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserEvent)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserEvent>()
                .HasOne(pt => pt.Event)
                .WithMany(t => t.UserEvent)
                .HasForeignKey(pt => pt.EventId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
