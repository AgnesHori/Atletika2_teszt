using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika2.Models
{
    [Table("Versenyzo")]

    public class Versenyzo
    {
        [Key]
        public int VersId { get; set; }
        public string Nev { get; set; }
        public bool Neme { get; set; }
    }
}
