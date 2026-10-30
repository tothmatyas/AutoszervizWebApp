using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoszervizWebApp.Models;
using AutoszervizWebApp.Data;

namespace AutoszervizWebApp.Pages.UgyfelPages;

public class IndexModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public IndexModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    public IList<Ugyfel> Ugyfel { get; set; } = default!;
    public IList<Javitas> Javitasok { get; set; } = default!;
    public IList<string> Allapotok { get; set; } = default!;
    public string? KivalasztottAllapot { get; set; }

    public async Task OnGetAsync(string? allapot)
    {
        Ugyfel = await _context.Ugyfelek.Include(u => u.Javitasok).ToListAsync();
        Allapotok = await _context.Javitasok.Select(j => j.Allapot).Distinct().OrderBy(a => a).ToListAsync();
        KivalasztottAllapot = allapot;

        var javitasok = _context.Javitasok.Include(j => j.Ugyfel).AsQueryable();
        if (!string.IsNullOrEmpty(allapot))
            javitasok = javitasok.Where(j => j.Allapot == allapot);
        Javitasok = await javitasok.ToListAsync();
    }
}
