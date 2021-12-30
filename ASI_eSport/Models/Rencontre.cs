using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASI_eSport.Models
{
    public class Rencontre
    {
        public int ID { get; set; }

        [Display(Name = "Date de la rencontre")]
        [DataType(DataType.Date)]
        public DateTime DateRencontre { get; set; }
        public int? CompetitionconcerneeID { get; set; }
        // Lien de navigation
        public Competition Competitionconcernee { get; set; }
    }
}
