using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Jeu
    {
        public int ID { get; set; }
        [Required]
        public string LibelleJeu { get; set; } // exp football

        //public ICollection<Equipe> EquipesInscrites { get; set; }
        //Lien ManyToMany
        [Display(Name = "Compétitions incluants le jeu")]
        public ICollection<Jeu_competition> Jeux_Competitions { get; set; }

    }
}
