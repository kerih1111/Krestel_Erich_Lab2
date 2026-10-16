using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Krestel_Erich_Lab2.Models;

namespace Krestel_Erich_Lab2.Pages.PublicatorPages;

public class IndexModel : PageModel
{
    private readonly Krestel_Erich_Lab2Context _context;

    public IndexModel(Krestel_Erich_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publicator> Publicator { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publicator = await _context.Publicator
            .Include(p => p.Books)
            .ToListAsync();
    }
}
