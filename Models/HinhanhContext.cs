using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationHinh.Models;

public partial class HinhanhContext : DbContext
{
    public HinhanhContext()
    {
    }

    public HinhanhContext(DbContextOptions<HinhanhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hocvien> Hocviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=msi;Initial Catalog=hinhanh;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hocvien>(entity =>
        {
            entity.HasKey(e => e.Mshv).HasName("PK__hocvien__763F34B7CCD2EEB4");

            entity.ToTable("hocvien");

            entity.Property(e => e.Mshv)
                .HasMaxLength(50)
                .HasColumnName("mshv");
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasColumnName("hinh");
            entity.Property(e => e.Tenhv)
                .HasMaxLength(50)
                .HasColumnName("tenhv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
