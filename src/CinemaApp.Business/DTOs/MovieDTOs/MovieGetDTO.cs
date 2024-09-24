using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.MovieDTOs
{
    public record MovieGetDTO(int Id, string Title, string Desc, string Genre, string Duration, string Rating, bool isDeleted, DateTime ReleseDate);
}
