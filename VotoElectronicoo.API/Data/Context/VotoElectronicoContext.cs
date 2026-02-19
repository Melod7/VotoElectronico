using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using VotoElectronicoo.API.Models;

namespace VotoElectronicoo.API.Data
{
    public class VotoElectronicoContext : DbContext
    {
        public VotoElectronicoContext(DbContextOptions<VotoElectronicoContext> options)
            : base(options) { }

        public DbSet<Voto> Votos { get; set; }
        public DbSet<CodigoVotacion> CodigoVotacion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Votante> Votantes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<JefeJunta> JefeJunta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().ToTable("administradores");
        }
    }
}
