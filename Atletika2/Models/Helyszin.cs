using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika2.Models
{
    [Table("Helyszin")]

    public class Helyszin
    {  
        [Key]
        public int HelyId { get; set; }
        public int Ev { get; set; }
        public string Orszag { get; set; }
        public string Varos { get; set; }

    }
}
