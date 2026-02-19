using System.ComponentModel.DataAnnotations;

namespace Proiect_web_Frizerie.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client? Client { get; set; }
        public int StylistID { get; set; }

        [Display(Name = "Stilist")]
        public Stylist? Stylist { get; set; }
        public int ServiceID { get; set; }

        [Display(Name = "Serviciu")]
        public Service? Service { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data și ora programării")]
        public DateTime DataOra { get; set; }
    }
}
