using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Rencontres
{
    public class CreateModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public CreateModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompetitionconcerneeID"] = new SelectList(_context.Competition, "ID", "LibelleCompetion");
            return Page();
        }

        [BindProperty]
        public Rencontre Rencontre { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rencontre.Add(Rencontre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
