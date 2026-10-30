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

    public async Task OnGetAsync()
    {
        Ugyfel = await _context.Ugyfelek.Include(u => u.Javitasok).ToListAsync();
        Javitasok = await _context.Javitasok.Include(j => j.Ugyfel).ToListAsync();
    }
}
