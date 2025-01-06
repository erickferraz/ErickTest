using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ErickTest.Data;
using ErickTest.Models;

namespace ErickTest.Pages_Premiums
{
    public class EditModel : PageModel
    {
        private readonly ErickTest.Data.ApplicationDbContext _context;

        public EditModel(ErickTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premiums == null)
            {
                return NotFound();
            }

            var premium =  await _context.Premiums.FirstOrDefaultAsync(m => m.id == id);
            if (premium == null)
            {
                return NotFound();
            }
            Premium = premium;
           ViewData["StudantId"] = new SelectList(_context.Studants, "id", "Email");
            return Page();
        } 
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Premium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumExists(Premium.id))
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

        private bool PremiumExists(int id)
        {
          return (_context.Premiums?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
