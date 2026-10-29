using Krestel_Erich_Lab2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Krestel_Erich_Lab2.Data;

public class Krestel_Erich_Lab2Context(DbContextOptions<Krestel_Erich_Lab2Context> options)
    : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publicator> Publicator { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<Member> Member { get; set; } = default!;
    public DbSet<Borrowing> Borrowing { get; set; } = default!;
}