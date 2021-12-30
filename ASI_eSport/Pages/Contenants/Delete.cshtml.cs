using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Contenants
{
    public class DeleteModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public DeleteModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contenir Contenir { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contenir = await _context.Contenir
                .Include(c => c.LEquipe)
                .Include(c => c.LeLicencie).FirstOrDefaultAsync(m => m.ID == id);

            if (Contenir == null)
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

            Contenir = await _context.Contenir.FindAsync(id);

            if (Contenir != null)
            {
                _context.Contenir.Remove(Contenir);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
