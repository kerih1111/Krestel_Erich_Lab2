using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Krestel_Erich_Lab2.Models;

namespace Krestel_Erich_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Krestel_Erich_Lab2Context _context;

    public IndexModel(Krestel_Erich_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;
    public Category SelectedCategory { get; set; }
    public int CategoryID { get; set; }
    

    public async Task OnGetAsync(int? id)
    {
        Category = await _context.Category
            .Include(i => i.BookCategories)
                .ThenInclude(b=> b.Book)
                    .ThenInclude(a => a.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

        if(id != null)
        {
            CategoryID = id.Value;
            SelectedCategory = Category
                .Where(i => i.ID == id.Value)
                .Single();
        }

    }
}
