using AutoszervizWebApp.Data;
using AutoszervizWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoszervizWebApp.Pages.JavitasPages;

public class DeleteModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public DeleteModel(AutoszervizDbContext context) => _context = context;

    public Javitas Javitas { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return NotFound();
        Javitas = await _context.Javitasok.Include(j => j.Ugyfel).FirstOrDefaultAsync(j => j.Id == id);
        return Javitas is null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var javitas = await _context.Javitasok.FindAsync(id);
        if (javitas is not null)
        {
            _context.Javitasok.Remove(javitas);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("/UgyfelPages/Index");
    }
}
