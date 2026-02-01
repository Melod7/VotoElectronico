using Microsoft.EntityFrameworkCore;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Votante> Votantes { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
    }
}