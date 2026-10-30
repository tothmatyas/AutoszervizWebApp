using AutoszervizWebApp.Data;
using AutoszervizWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoszervizWebApp.Pages.JavitasPages;

public class EditModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public EditModel(AutoszervizDbContext context) => _context = context;

    [BindProperty]
    public Javitas Javitas { get; set; } = default!;

    public SelectList Ugyfelek { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return NotFound();
        Javitas = await _context.Javitasok.FindAsync(id);
        if (Javitas is null) return NotFound();
        await UgyfelekBetolteseAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string allapot)
    {
        if (allapot is "Felvéve" or "Folyamatban" or "Kész")
            Javitas.Allapot = allapot;

        if (Javitas.Allapot == "Kész" && Javitas.Koltseg == 0)
            ModelState.AddModelError("Javitas.Koltseg", "A javítás csak 0-nál nagyobb költséggel állítható kész állapotba.");

        if (!ModelState.IsValid)
        {
            await UgyfelekBetolteseAsync();
            return Page();
        }

        _context.Attach(Javitas).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("/UgyfelPages/Index");
    }

    private async Task UgyfelekBetolteseAsync() =>
        Ugyfelek = new SelectList(await _context.Ugyfelek.ToListAsync(), "Id", "Nev");
}
