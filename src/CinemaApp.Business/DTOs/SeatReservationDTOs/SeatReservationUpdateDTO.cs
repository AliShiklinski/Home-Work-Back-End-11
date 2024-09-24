using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.SeatReservationDTOs
{
    public record SeatReservationUpdateDTO((int Id, string SeatNumber, int ShowTimeId, bool IsBooked)
    {
    }
}
