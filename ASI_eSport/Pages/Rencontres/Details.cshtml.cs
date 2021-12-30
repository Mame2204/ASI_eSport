using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Rencontres
{
    public class DetailsModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DetailsModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Rencontre Rencontre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rencontre = await _context.Rencontre
                .Include(r => r.Competitionconcernee).FirstOrDefaultAsync(m => m.ID == id);

            if (Rencontre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
