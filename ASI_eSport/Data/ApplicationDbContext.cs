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
        public DbSet<Rencontre> Rencontre { get; set; }
        public DbSet<Jeu_competition> Jeu_competition { get; set; }
        public DbSet<Contenir> Contenir { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contenir>()
                .HasKey(le => new { le.LEquipeID, le.LeLicencieID });
        }*/
    }
}
