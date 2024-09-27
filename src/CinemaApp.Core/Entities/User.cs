using CinemaApp.Core.Entities.Base;
using CinemaApp.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Entities
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }
       
    }
}
