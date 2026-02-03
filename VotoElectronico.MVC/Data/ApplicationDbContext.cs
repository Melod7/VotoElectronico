using Microsoft.EntityFrameworkCore;
using VotoElectronico.MVC.Models;
using VotoElectronico.MVC.Data;

namespace VotoElectronico.MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Votante> Votantes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<JefeJunta>JefesJunta { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
    }
}


      
    
