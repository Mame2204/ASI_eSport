﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Rencontres
{
    public class EditModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public EditModel(ASI_eSport.Data.ApplicationDbContext context)
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
           ViewData["CompetitionconcerneeID"] = new SelectList(_context.Competition, "ID", "LibelleCompetion");
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

            _context.Attach(Rencontre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RencontreExists(Rencontre.ID))
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

        private bool RencontreExists(int id)
        {
            return _context.Rencontre.Any(e => e.ID == id);
        }
    }
}
