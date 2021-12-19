using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASI_eSport.Data;
using ASI_eSport.Models;

namespace ASI_eSport.Pages.Competitions
{
    public class IndexModel : PageModel
    {
        private readonly ASI_eSport.Data.ApplicationDbContext _context;

        public IndexModel(ASI_eSport.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Competition> Competition { get;set; }

        public async Task OnGetAsync()
        {
            Competition = await _context.Competition.ToListAsync();
        }
    }
}
