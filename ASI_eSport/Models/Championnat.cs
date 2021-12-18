using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Championnat
    {
        public int ID { get; set; }
        // Clé étrangère
        [Display(Name = "Equipe1")]
        public int Equipe1ID { get; set; }
        //Lien de navigation
        [Display(Name = "Equipe1")]
        public Equipe Equipe1 { get; set; }
        // Clé étrangère
        //[Display(Name = "Equipe2")]
        //public int Equipe2ID { get; set; }
        ////Lien de navigation
        //[Display(Name = "Equipe2")]
        //public Equipe Equipe2 { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateJeu { get; set; }
        public string TypeFormule { get; set; }

    }
}
