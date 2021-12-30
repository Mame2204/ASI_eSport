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
    public class DeleteModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DeleteModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rencontre = await _context.Rencontre.FindAsync(id);

            if (Rencontre != null)
            {
                _context.Rencontre.Remove(Rencontre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
