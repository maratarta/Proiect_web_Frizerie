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

namespace Proiect_web_Frizerie.Pages.Specialties
{

    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext _context;

        public IndexModel(Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        public IList<Specialty> Specialty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Specialty = await _context.Specialty.ToListAsync();
        }
    }
}
