using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.JeuxCompetition
{
    public class DetailsModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DetailsModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Jeu_competition Jeu_competition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jeu_competition = await _context.Jeu_competition
                .Include(j => j.LeJeu).FirstOrDefaultAsync(m => m.ID == id);

            if (Jeu_competition == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
