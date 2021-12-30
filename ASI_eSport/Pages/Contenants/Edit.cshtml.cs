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

namespace ASI_eSport.Pages.Contenants
{
    public class EditModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public EditModel(ASI_eSport.Data.ApplicationDbContext context)
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
           ViewData["LEquipeID"] = new SelectList(_context.Equipe, "ID", "NomEquipe");
           ViewData["LeLicencieID"] = new SelectList(_context.Licencie, "ID", "NomComplet");
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

            _context.Attach(Contenir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContenirExists(Contenir.ID))
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

        private bool ContenirExists(int id)
        {
            return _context.Contenir.Any(e => e.ID == id);
        }
    }
}
