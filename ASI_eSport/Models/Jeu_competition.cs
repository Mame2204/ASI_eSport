using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASI_eSport.Models
{
    public class Jeu_competition
    {
        //Clé primaire
        public int ID { get; set; }
        //Lien de composition vers la compétition
        public int LaCompetitionID { get; set;}
        public Competition LaCompetition { get; set;}
        //Lien de composition vers l'UE
        public int LeJeuID { get; set; }
        public Jeu LeJeu { get; set; }
    }
}
