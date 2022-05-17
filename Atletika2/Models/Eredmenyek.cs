using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika2.Models
{
    [Table("Eredmenyek")]

    public class Eredmenyek
    {
        [ForeignKey("Helyszin")]
        public int HelyId { get; set; }
        public virtual Helyszin Helyszin { get; set; }

        [ForeignKey("Versenyzo")]
        public int VersId { get; set; }
        public virtual Versenyzo Versenyzo { get; set; }

        public string Versenyszam { get; set; }
        public int? Helyezes { get; set; }


    }
}
