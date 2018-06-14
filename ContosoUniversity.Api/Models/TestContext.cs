using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Models
{
    public partial class TestContext : DbContext
    {
        public Connection conn;
        public TestContext(Connection connection)
        {
            conn = connection;
        }
        
        //public TestContext(DbContextOptions<TestContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Enrollments> Enrollments { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Enrollments>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId);

                entity.Property(e => e.EnrollmentId)
                    .HasColumnName("EnrollmentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            });
        }
    }
}
