using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Areas.AddTask.Models;

public partial class TempxContext : DbContext
{
    public TempxContext()
    {
    }

    public TempxContext(DbContextOptions<TempxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todoapp> Todoapps { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todoapp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__todoapp__3214EC273CAA8B2C");

            entity.ToTable("todoapp");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
