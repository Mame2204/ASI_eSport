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
    }
}
