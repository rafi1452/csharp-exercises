using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exercises.DataObjects
{
    public partial class flowers_dbContext : DbContext
    {
        public flowers_dbContext()
        {
        }

        public flowers_dbContext(DbContextOptions<flowers_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Iris> Irises { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=8080;user=root;password=1234;database=flowers_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Iris>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("iris");

                entity.Property(e => e.PetalLength).HasColumnName("petal_length");

                entity.Property(e => e.PetalWidth).HasColumnName("petal_width");

                entity.Property(e => e.SepalLength).HasColumnName("sepal_length");

                entity.Property(e => e.SepalWidth).HasColumnName("sepal_width");

                entity.Property(e => e.Species)
                    .HasColumnType("text")
                    .HasColumnName("species");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
