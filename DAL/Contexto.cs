using Microsoft.EntityFrameworkCore;
using Registro.Entidades;

public class Contexto:DbContext
{
    
    public DbSet<Carrera> Carrera { get; set; } 
    public DbSet<Estudiante> Estudiante { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data\Incripcion.db");
    }
}