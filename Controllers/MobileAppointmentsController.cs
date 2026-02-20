using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_web_Frizerie.Data;
using Proiect_web_Frizerie.Models;

namespace Proiect_web_Frizerie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileAppointmentsController : ControllerBase
    {
        private readonly Proiect_web_FrizerieContext _context;

        public MobileAppointmentsController(Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        // metoda care primește ID-ul clientului si ii returnează programarile lui
        [HttpGet("{userId}")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMyAppointments(string userId)
        {
            // facem string-ul primit de la telefon într-un numar (int)
            if (!int.TryParse(userId, out int idClient))
            {
                return BadRequest(new { message = "ID utilizator invalid." });
            }

            var programari = await _context.Appointment
                .Include(p => p.Service)
                .Include(p => p.Stylist)
                .Where(p => p.ClientID == idClient) // comparamint cu int
                .OrderByDescending(p => p.DataOra)
                .ToListAsync();

            if (programari == null || !programari.Any())
            {
                return Ok(new List<Appointment>());
            }

            return Ok(programari);
        }
        [HttpPost]
        public async Task<IActionResult> PostAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null) return BadRequest();

            // Adaugam programarea in baza de date
            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Programare creată!" });
        }
    }
}