using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Equipes
{
    public class DeleteModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DeleteModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipe = await _context.Equipe.FirstOrDefaultAsync(m => m.ID == id);

            if (Equipe == null)
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

            Equipe = await _context.Equipe.FindAsync(id);

            if (Equipe != null)
            {
                _context.Equipe.Remove(Equipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
