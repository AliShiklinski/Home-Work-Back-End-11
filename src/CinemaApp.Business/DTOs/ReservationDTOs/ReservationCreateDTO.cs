using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.ReservationDTOs
{
    public record ReservationCreateDTO(int Id, DateTime ReservationDate, int UserId){}

}
