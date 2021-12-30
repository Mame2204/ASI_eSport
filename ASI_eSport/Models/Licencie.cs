using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Licencie
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime Naissance { get; set; }
        public Boolean Statut { get; set; }
        // Lien de navigation ManyToMany
        [Display(Name = "les liencies de l'equipe")]
        public ICollection<Contenir> LesContenir { get; set; }

        [Display(Name = "Nom du licencie")]
        public string NomComplet
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }
    }
}
