namespace Proiect_web_Frizerie.Models
{
    public class Specialty
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public ICollection<Stylist>? Stylists { get; set; }
    }
}
