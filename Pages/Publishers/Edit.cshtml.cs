using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Krestel_Erich_Lab2.Models;

namespace Krestel_Erich_Lab2.Pages.PublicatorPages;

public class EditModel : PageModel
{
    private readonly Krestel_Erich_Lab2Context _context;

    public EditModel(Krestel_Erich_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Publicator Publicator { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var publicator = await _context.Publicator.FirstOrDefaultAsync(m => m.ID == id);
        if (publicator is null)
        {
            return NotFound();
        }
        Publicator = publicator;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Publicator).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PublicatorExists(Publicator.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool PublicatorExists(int id)
    {
        return _context.Publicator.Any(e => e.ID == id);
    }
}
