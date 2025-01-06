using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ErickTest.Data;
using ErickTest.Models;

namespace ErickTest.Pages_Premiums
{
    public class CreateModel : PageModel
    {
        private readonly ErickTest.Data.ApplicationDbContext _context;

        public CreateModel(ErickTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudantId"] = new SelectList(_context.Studants, "id", "Email");
            return Page();
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Premiums == null || Premium == null)
            {
                return Page();
            }

            _context.Premiums.Add(Premium);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
