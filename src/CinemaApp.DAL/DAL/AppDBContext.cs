using CinemaApp.Core.Entities;
using CinemaApp.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.DAL
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> Showtimes { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

