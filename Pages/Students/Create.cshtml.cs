using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ErickTest.Data;
using ErickTest.Models;

namespace ErickTest.Pages_Students
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
            return Page();
        }

        [BindProperty]
        public Studant Studant { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Studants == null || Studant == null)
            {
                return Page();
            }

            _context.Studants.Add(Studant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
