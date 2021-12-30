using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Contenir
    {
        //Clé primaire
        public int ID { get; set; }

        //Lien de composition vers le licencie
        [Display(Name = "Nom du licencie")]
        public int LeLicencieID {get; set;} 
        public Licencie LeLicencie { get; set; }

        //Lien de composition vers l'Equipe
        [Display(Name = "Nom de l'equipe")]
        public int LEquipeID { get; set; }
        public Equipe LEquipe { get; set; }
    }
}
