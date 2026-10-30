using AutoszervizWebApp.Data;
using AutoszervizWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoszervizWebApp.Pages.JavitasPages;

public class CreateModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public CreateModel(AutoszervizDbContext context) => _context = context;

    [BindProperty]
    public Javitas Javitas { get; set; } = new() { Allapot = "Felvéve", FelvetelDatuma = DateTime.Now };

    public SelectList Ugyfelek { get; set; } = default!;

    public async Task OnGetAsync() => await UgyfelekBetolteseAsync();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await UgyfelekBetolteseAsync();
            return Page();
        }

        _context.Javitasok.Add(Javitas);
        await _context.SaveChangesAsync();
        return RedirectToPage("/UgyfelPages/Index");
    }

    private async Task UgyfelekBetolteseAsync() =>
        Ugyfelek = new SelectList(await _context.Ugyfelek.ToListAsync(), "Id", "Nev");
}
