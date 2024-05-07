using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PPKDotNetCore.ConsoleApp.Models;

public partial class PPKDotNetTrainingBatch4AppDbContext : DbContext
{
    public PPKDotNetTrainingBatch4AppDbContext()
    {
    }

    public PPKDotNetTrainingBatch4AppDbContext(DbContextOptions<PPKDotNetTrainingBatch4AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL2019E;Database=PPKDotNetTrainingBatch4;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=true;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
