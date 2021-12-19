using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Competition
    {
        public int ID { get; set; }
        [Required]
        public string LibelleCompetion{ get; set; } // ex: coupe du monde

        // Lien de navigation ManyToMany
        [Display(Name = "Jeux de la compétition")]
        public ICollection<Jeu_competition> Jeux_Competitions { get; set; }

    }
}
