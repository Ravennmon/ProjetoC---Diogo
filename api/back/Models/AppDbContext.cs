namespace back.Models;

using Microsoft.EntityFrameworkCore;
using back.Enums;

public class AppDbContext : DbContext
{
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Ong> Ongs { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Animal> Animais { get; set; }
    public DbSet<RedeSocial> RedeSociais { get; set; }
    public DbSet<AnimalFoto> AnimalFotos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=amor_pet.db");
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ong>()
                    .Navigation(o => o.Animais).AutoInclude();
        
        modelBuilder.Entity<Animal>()
                    .Navigation(a => a.Fotos).AutoInclude();

        modelBuilder.Entity<Animal>()
                    .Property(o => o.Tipo)
                    .HasConversion(
                        v => v.ToString(),
                        v => (TipoAnimal)Enum.Parse(typeof(TipoAnimal), v)
                    );
            
        modelBuilder.Entity<Ong>()
                    .Navigation(o => o.Servicos).AutoInclude();
        
        modelBuilder.Entity<Ong>()
                    .Navigation(o => o.RedesSociais).AutoInclude();

        
        modelBuilder.Entity<Tutor>()
                    .Navigation(t => t.RedesSociais).AutoInclude();

        modelBuilder.Entity<Tutor>()
                    .Navigation(t => t.Animais).AutoInclude();
    }
}