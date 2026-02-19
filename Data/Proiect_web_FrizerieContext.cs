using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Proiect_web_Frizerie.Models;

namespace Proiect_web_Frizerie.Data
{
    public class Proiect_web_FrizerieContext : IdentityDbContext
    {
        public Proiect_web_FrizerieContext (DbContextOptions<Proiect_web_FrizerieContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_web_Frizerie.Models.Client> Client { get; set; } = default!;
        public DbSet<Proiect_web_Frizerie.Models.Stylist> Stylist { get; set; } = default!;
        public DbSet<Proiect_web_Frizerie.Models.Specialty> Specialty { get; set; } = default!;
        public DbSet<Proiect_web_Frizerie.Models.Service> Service { get; set; } = default!;
        public DbSet<Proiect_web_Frizerie.Models.Appointment> Appointment { get; set; } = default!;
    }
}
