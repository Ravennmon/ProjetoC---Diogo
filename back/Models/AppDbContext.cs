namespace back.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Ong> Ongs { get; set; }
    public DbSet<Cuidador> Cuidadores { get; set; }
    public DbSet<Animal> Animais { get; set; }
    public DbSet<RedeSocial> RedeSociais { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=amor_pet.db");
    }
}