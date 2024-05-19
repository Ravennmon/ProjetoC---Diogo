using BACK.Models;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Ongs> Ongs { get; set; }
    public DbSet<AnimalFoto> AnimalFotos { get; set; }
    public DbSet<Animal> Animais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=amor_pet.db");
    }

    
}