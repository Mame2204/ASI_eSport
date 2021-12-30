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
    public class IndexModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public IndexModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contenir> Contenir { get;set; }
        public int EquipeID { get; set; }
        [BindProperty]
        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            { return NotFound(); }

            //Récupération de l'ID de l'enseignant dont on veut gérer les UEs
            EquipeID = (int)id;

            // Récupération des UEs de cet enseignant
            Equipe = _context.Equipe.Find(id);

            // Récupération des UEs de cet enseignant
            Contenir = await _context.Contenir
                .Include(e => e.LEquipe)
                .Where(e => e.LEquipe.ID == id)
                .Include(e => e.LeLicencie)
                .ToListAsync();
            if (Contenir == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}