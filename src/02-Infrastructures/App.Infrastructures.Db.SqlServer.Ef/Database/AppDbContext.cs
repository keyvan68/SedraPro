using App.Domain.Core.DtoModels.UserDetailsDtoModels;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Db.SqlServer.Ef.Database
{
    public partial class AppDbContext : DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer("Server=.;Database=SerkanDB;Integrated Security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Family).HasMaxLength(50);
                entity.HasOne<UserDetails>(ad => ad.UserDetails)
                 .WithOne(s => s.User)
                 .HasForeignKey<UserDetails>(ad => ad.UserDetailsId);

            });
            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.ToTable("UserDetails");
                entity.Property(e => e.Gender).HasMaxLength(10);


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
