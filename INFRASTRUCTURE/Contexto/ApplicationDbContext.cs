using DOMAIN.Entities.Archivos;
using DOMAIN.Entities.Inventario;
using DOMAIN.Entities.Persona;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Contexto
{
    public class ApplicationDbContext : IdentityDbContext<Usuarios, Rol, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> tbl_usuario { set; get; }
        public DbSet<Rol> tbl_rol { set; get; }
        public DbSet<ImagenesProducto> tbl_ImagenesProducto { set; get; }
        public DbSet<ImagenesPersona> tbl_ImagenesPersona { set; get; }
        public DbSet<Producto> tbl_producto { set; get; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<T> InsertarEntidad<T>(T entidad)
        {
            try
            {
                Add(entidad);
                await SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw new DbUpdateConcurrencyException().InnerException;
            }
        }
        public async Task<T> UpdateEntidad<T>(T entidad)
        {
            try
            {
                Update(entidad);
                await SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw new DbUpdateConcurrencyException();
            }
        }
        public async Task<T> Dellete<T>(T entidad)
        {
            try
            {
                Remove(entidad);
                await SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw new DbUpdateConcurrencyException();
            }
        }

        public async Task<T> PachtEntidad<T>(T entidad)
        {
            try
            {
                Entry(entidad).State = EntityState.Modified;
                await SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw new DbUpdateConcurrencyException();
            }
        }
    }
}
