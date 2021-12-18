using ASI_eSport.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASI_eSport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Licencie> Licencie { get; set; }
        public DbSet<Championnat> Championnat { get; set; }
        public DbSet<Jeu> Jeu { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        

    }
}
