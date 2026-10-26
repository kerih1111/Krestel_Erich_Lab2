using Microsoft.EntityFrameworkCore;

public class Krestel_Erich_Lab2Context(DbContextOptions<Krestel_Erich_Lab2Context> options) : DbContext(options)
{
    public DbSet<Krestel_Erich_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Krestel_Erich_Lab2.Models.Publicator> Publicator { get; set; } = default!;
    public DbSet<Krestel_Erich_Lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Krestel_Erich_Lab2.Models.Category> Category { get; set; } = default!;


}
