using System.ComponentModel.DataAnnotations;

namespace Proiect_web_Frizerie.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Numele trebuie sa aiba minim 2 caractere si maxim 50.")]
        [RegularExpression(@"^[a-zA-Z\s\-]*$", ErrorMessage = "Folositi doar litere si spatii.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Prenumele trebuie sa aiba minim 2 caractere si maxim 50.")]
        [RegularExpression(@"^[a-zA-Z\s\-]*$", ErrorMessage = "Folositi doar litere si spatii.")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Adresa de email este obligatorie.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numarul de telefon este obligatoriu.")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numarul de telefon trebuie sa contina exact 10 cifre.")]
        public string Telefon { get; set; }
        public string NumeComplet => $"{Nume} {Prenume}";


    }
}
