using Microsoft.EntityFrameworkCore;
using StudentEventAPI.Models;

namespace StudentEventAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Prevent duplicate registrations (same student + same event)
            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.StudentId, r.EventId })
                .IsUnique();

            // Student -> Registrations
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Registrations)
                .HasForeignKey(r => r.StudentId);

            // Event -> Registrations
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            // Event -> Feedbacks
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Event)
                .WithMany(e => e.Feedbacks)
                .HasForeignKey(f => f.EventId);
        }
    }
}