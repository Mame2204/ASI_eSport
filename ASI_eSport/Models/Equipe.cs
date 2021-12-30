using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Equipe
    {
        public int ID { get; set; }
        public string NomEquipe { get; set; }
        // Clé étrangère vers le jeu 
        // Porte le nom du lien de navigation suivi du nom de la clé primaire de jeu
        public int? JeuChoisiID { get; set; }
        // Lien de navigation
        public Jeu JeuChoisi { get; set; }

        
        // Lien de navigation ManyToMany
        [Display(Name = "les equipes du liencie")]
        public ICollection<Contenir> LesContenir { get; set; }
    }
}
