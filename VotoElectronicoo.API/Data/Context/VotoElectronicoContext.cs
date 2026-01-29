using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.Models;

namespace VotoElectronico.API.Data
{
    public class VotoElectronicoContext : DbContext
    {
        public VotoElectronicoContext(DbContextOptions<VotoElectronicoContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Eleccion> Elecciones => Set<Eleccion>();
        public DbSet<Candidato> Candidatos => Set<Candidato>();
        public DbSet<Voto> Votos => Set<Voto>();
        public DbSet<CodigoAutenticacion> CodigosAutenticacion => Set<CodigoAutenticacion>();

    }
}
