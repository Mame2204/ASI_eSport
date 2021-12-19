using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASI_eSport.Data;
using ASI_eSport.Models;
using Microsoft.EntityFrameworkCore;

namespace ASI_eSport.Pages.JeuxCompetition
{
    public class CreateModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;
        public Competition Competition { get; set; }
        [BindProperty]
        public Jeu_competition Jeu_competition { get; set; }

        public CreateModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Competition = await _context.Competition.FirstOrDefaultAsync(m => m.ID == (int)id);
            ViewData["LeJeuID"] = new SelectList(_context.Jeu, "ID", "LibelleJeu");
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jeu_competition.Add(Jeu_competition);
            await _context.SaveChangesAsync();

            return RedirectToPage("../JeuxCompetition/Index", new { id = Jeu_competition.LaCompetitionID });

        }
    }
}
