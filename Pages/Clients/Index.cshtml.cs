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

namespace Proiect_web_Frizerie.Pages.Clients
{

    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext _context;

        public IndexModel(Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Client.ToListAsync();
        }
    }
}
