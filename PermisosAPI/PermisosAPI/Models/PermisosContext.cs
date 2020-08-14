using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermisosAPI.Models
{
    public class PermisosContext : DbContext
    {
        public DbSet<TipoPermiso> TiposPermisos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>()
                        .HasOne(p => p.TipoPermiso)
                        .WithMany(tp => tp.Permisos)
                        .HasForeignKey(p => p.TipoPermisoId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LP-IMP09;Database=PermisosDB;Trusted_Connection=True;");
        }
    }
}
