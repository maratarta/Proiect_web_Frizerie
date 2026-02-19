using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Proiect_web_Frizerie.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Denumire { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
    }
}
