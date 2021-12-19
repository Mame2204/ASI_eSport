using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.JeuxCompetition
{
    public class EditModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public EditModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["LeJeuID"] = new SelectList(_context.Jeu, "ID", "LibelleJeu");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jeu_competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Jeu_competitionExists(Jeu_competition.ID))
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

        private bool Jeu_competitionExists(int id)
        {
            return _context.Jeu_competition.Any(e => e.ID == id);
        }
    }
}
