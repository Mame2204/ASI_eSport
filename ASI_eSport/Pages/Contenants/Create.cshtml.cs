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

namespace ASI_eSport.Pages.Contenants
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Contenir contenir { get; set; }

        [BindProperty]
        public Equipe equipe { get; set; }

        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public CreateModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            { return NotFound(); }

            //Récupération de l'ID de l'enseignant dont on veut gérer les UEs
            equipe = await _context.Equipe
                .FirstOrDefaultAsync(m => m.ID == (int)id);
            ViewData["LeLicencieID"] = new SelectList (_context.Licencie, "ID", "NomComplet"); 
            
            //MultiSelectList
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contenir.Add(contenir);
            await _context.SaveChangesAsync();
            return RedirectToPage("../Contenants/Index", new { id = contenir.LEquipeID });
        }
    }
}