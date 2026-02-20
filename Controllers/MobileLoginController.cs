using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Proiect_web_Frizerie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileLoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public MobileLoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // primim datele de la telefon
        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // caut clientul în baza de date dupa adresa de email
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                // verifica daca parola trimisa de telefon se potriveste cu cea din baza de date
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    // daca e corecta, ii dam telefonului un raspuns de SUCCES si ID-ul clientului
                    return Ok(new { success = true, userId = user.Id, message = "Autentificare cu succes!" });
                }
            }

            // daca nu gaseste mailu sau parola e gresita, ii dam EROARE
            return Unauthorized(new { success = false, message = "Email sau parolă incorectă." });
        }
        // Plicul cu datele de înregistrare
        public class RegisterModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // creare utilizatorul în sistemul identity
            var user = new IdentityUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { success = true, message = "Cont creat cu succes!" });
            }

            // daca identity respinge datele , trimitem erorile înapoi
            return BadRequest(new { success = false, errors = result.Errors.Select(e => e.Description) });
        }
    }
}