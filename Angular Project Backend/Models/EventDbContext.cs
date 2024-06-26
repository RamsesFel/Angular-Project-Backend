using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Angular_Project_Backend.Models;

public partial class EventDbContext : DbContext
{
    public EventDbContext()
    {
    }

    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<UserId> UserIds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=EventDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3213E83FBBC312AD");

            entity.ToTable("Event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3213E83F685AA082");

            entity.ToTable("Favorite");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.IsFavorite).HasColumnName("isFavorite");
            entity.Property(e => e.UserId).HasColumnName("userId");


            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favorite__userId__4D94879B");
        });

        modelBuilder.Entity<UserId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userId__3213E83F24BDE641");

            entity.ToTable("userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
