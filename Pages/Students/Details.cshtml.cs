using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ErickTest.Data;
using ErickTest.Models;

namespace ErickTest.Pages_Students
{
    public class DetailsModel : PageModel
    {
        private readonly ErickTest.Data.ApplicationDbContext _context;

        public DetailsModel(ErickTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Studant Studant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Studants == null)
            {
                return NotFound();
            }

            var studant = await _context.Studants.FirstOrDefaultAsync(m => m.id == id);
            if (studant == null)
            {
                return NotFound();
            }
            else 
            {
                Studant = studant;
            }
            return Page();
        }
    }
}
