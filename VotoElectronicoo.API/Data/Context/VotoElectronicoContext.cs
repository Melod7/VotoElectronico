using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.Models;

namespace VotoElectronico.API.Data
{
    public class VotoElectronicoContext : DbContext
    {
        public VotoElectronicoContext(DbContextOptions<VotoElectronicoContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<CodigoAutenticacion> CodigosAutenticacion { get; set; }
    }
}