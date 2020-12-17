// <copyright file="TaskAssistantContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DBTaskAssistant
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class that configures DB connection.
    /// </summary>
    public partial class TaskAssistantContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskAssistantContext"/> class.
        /// </summary>
        public TaskAssistantContext() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskAssistantContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public TaskAssistantContext(DbContextOptions<TaskAssistantContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets task list from DB.
        /// </summary>
        public virtual DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets user list from DB.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Function that configures connections to DB.
        /// </summary>
        /// <param name="optionsBuilder">Builder that configures connection.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true);
                var strConnection = builder.Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(strConnection);
            }
        }

        /// <summary>
        /// Function that import model settings.
        /// </summary>
        /// <param name="modelBuilder">Builder that configures models.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(300);

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("username");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("user_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(30);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(6);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
