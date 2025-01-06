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

namespace ErickTest.Pages_Students
{
    public class EditModel : PageModel
    {
        private readonly ErickTest.Data.ApplicationDbContext _context;

        public EditModel(ErickTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Studant Studant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Studants == null)
            {
                return NotFound();
            }

            var studant =  await _context.Studants.FirstOrDefaultAsync(m => m.id == id);
            if (studant == null)
            {
                return NotFound();
            }
            Studant = studant;
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Studant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudantExists(Studant.id))
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

        private bool StudantExists(int id)
        {
          return (_context.Studants?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
