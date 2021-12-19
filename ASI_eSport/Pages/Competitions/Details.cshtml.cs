using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Competitions
{
    public class DetailsModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DetailsModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Competition Competition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Competition = await _context.Competition.FirstOrDefaultAsync(m => m.ID == id);
            Competition = await _context.Competition
                         .Include(i => i.Jeux_Competitions)
                         .ThenInclude(i => i.LeJeu)
                         .FirstOrDefaultAsync(m => m.ID == id);

            if (Competition == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
