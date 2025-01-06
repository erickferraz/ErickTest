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
    public class IndexModel : PageModel
    {
        private readonly ErickTest.Data.ApplicationDbContext _context;

        public IndexModel(ErickTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Studant> Studant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Studants != null)
            {
                Studant = await _context.Studants.ToListAsync();
            }
        }
    }
}
