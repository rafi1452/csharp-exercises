using System;
using System.Collections.Generic;
using Exercises.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Repository;

public partial class Flowers_DBDbContext : DbContext
{
    public Flowers_DBDbContext()
    {
    }

    public Flowers_DBDbContext(DbContextOptions<Flowers_DBDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iris> Irises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Flowers_DB;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
