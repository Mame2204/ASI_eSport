using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.JeuxCompetition
{
    public class IndexModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public IndexModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Jeu_competition> Jeu_competition { get;set; }
        public int CompetitionID { get; set; }
        public Competition Competition { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Récupération de l'ID de l'enseignant dont on veut gérer les UEs
            CompetitionID = (int)id;
            // Récupération des UEs de cet enseignant
            Competition = _context.Competition.Find(id);
            // Récupération des UEs de cet enseignant
            Jeu_competition = await _context.Jeu_competition
            .Include(e => e.LaCompetition).Where(e => e.LaCompetition.ID == id)
            .Include(e => e.LeJeu).ToListAsync();
            if (Jeu_competition == null)
            {
                return NotFound();
            }
            return Page();
        }

       
    }
}
