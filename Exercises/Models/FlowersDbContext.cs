using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Models;

public partial class FlowersDbContext : DbContext
{
    public FlowersDbContext()
    {
    }

    public FlowersDbContext(DbContextOptions<FlowersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iris> Irises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Flowers_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Iris>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("iris");

            entity.Property(e => e.PetalLength).HasColumnName("petal_length");
            entity.Property(e => e.PetalWidth).HasColumnName("petal_width");
            entity.Property(e => e.SepalLength).HasColumnName("sepal_length");
            entity.Property(e => e.SepalWidth).HasColumnName("sepal_width");
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .HasColumnName("species");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
