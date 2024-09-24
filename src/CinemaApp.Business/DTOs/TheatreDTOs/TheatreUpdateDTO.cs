﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.TheatreDTOs
{
    public record TheatreUpdateDTO(int Id, string Name, string Location, int TotalSeats)
    {
    }
}
