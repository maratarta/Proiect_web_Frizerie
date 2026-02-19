using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_web_Frizerie.Data;
using Proiect_web_Frizerie.Models;

namespace Proiect_web_Frizerie.Pages.Specialties
{

    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext _context;

        public EditModel(Proiect_web_Frizerie.Data.Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specialty Specialty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty =  await _context.Specialty.FirstOrDefaultAsync(m => m.ID == id);
            if (specialty == null)
            {
                return NotFound();
            }
            Specialty = specialty;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specialty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialtyExists(Specialty.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialty.Any(e => e.ID == id);
        }
    }
}
