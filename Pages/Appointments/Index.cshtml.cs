using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_web_Frizerie.Data;
using Proiect_web_Frizerie.Models;

namespace Proiect_web_Frizerie.Pages.Appointments
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext _context;

        public IndexModel(Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userEmail = User.Identity?.Name;


            var query = _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.Stylist)
                .Include(a => a.Service)
                .AsQueryable();

            if (User.IsInRole("Admin"))
            {
                Appointment = await query.ToListAsync();
            }
            else if (User.IsInRole("Client"))
            {
                Appointment = await query
                    .Where(a => a.Client.Email == userEmail)
                    .ToListAsync();
            }
        }
    }
}
