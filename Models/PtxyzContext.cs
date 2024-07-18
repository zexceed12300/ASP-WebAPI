using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PTXYZ_WEBAPI.Models;

public partial class PtxyzContext : DbContext
{
    public PtxyzContext()
    {
    }

    public PtxyzContext(DbContextOptions<PtxyzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblLapangan> TblLapangans { get; set; }

    public virtual DbSet<TblSewa> TblSewas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local)\\sqlexpress;Initial Catalog=PTXYZ;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblLapangan>(entity =>
        {
            entity.HasKey(e => e.IdLapangan);

            entity.ToTable("tbl_lapangan");

            entity.Property(e => e.IdLapangan).HasColumnName("id_lapangan");
            entity.Property(e => e.KodeLapangan)
                .HasMaxLength(50)
                .HasColumnName("kode_lapangan");
            entity.Property(e => e.NamaLapangan)
                .HasMaxLength(50)
                .HasColumnName("nama_lapangan");
        });

        modelBuilder.Entity<TblSewa>(entity =>
        {
            entity.HasKey(e => e.IdTransaksi);

            entity.ToTable("tbl_sewa");

            entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");
            entity.Property(e => e.IdLapangan).HasColumnName("id_lapangan");
            entity.Property(e => e.LamaSewa)
                .HasMaxLength(50)
                .HasColumnName("lama_sewa");
            entity.Property(e => e.NoTransaksi)
                .HasMaxLength(50)
                .HasColumnName("no_transaksi");
            entity.Property(e => e.TglTransaksi)
                .HasColumnType("date")
                .HasColumnName("tgl_transaksi");
            entity.Property(e => e.TotalBayar).HasColumnName("total_bayar");

            entity.HasOne(d => d.IdLapanganNavigation).WithMany(p => p.TblSewas)
                .HasForeignKey(d => d.IdLapangan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_sewa_tbl_lapangan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
