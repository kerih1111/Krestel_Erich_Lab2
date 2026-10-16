using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Krestel_Erich_Lab2.Models;

namespace Krestel_Erich_Lab2.Pages.PublicatorPages;

public class DetailsModel : PageModel
{
    private readonly Krestel_Erich_Lab2Context _context;
    public DetailsModel(Krestel_Erich_Lab2Context context)
    {
        _context = context;
    }

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
        else
        {
            Publicator = publicator;
        }

        return Page();
    }
}
