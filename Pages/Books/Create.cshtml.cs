using Krestel_Erich_Lab2.Migrations;
using Krestel_Erich_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Krestel_Erich_Lab2.Pages.BookPages;

public class CreateModel : PageModel
{
    private readonly Krestel_Erich_Lab2Context _context;

    public CreateModel(Krestel_Erich_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {

        ViewData["PublisherID"] = new SelectList(_context.Set<Publicator>(), "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");

        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
