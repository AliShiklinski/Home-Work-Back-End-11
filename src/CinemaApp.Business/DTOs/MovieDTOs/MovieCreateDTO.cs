using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.DTOs.MovieDTOs
{
  public record MovieCreateDTO(int Id, string Title, string Desc, string Genre, string Duration, string Rating, bool isDeleted, DateTime ReleseDate){}
    public class MovieCreateDtoValidator : AbstractValidator<MovieCreateDTO>
    {
        public MovieCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Not empty")
                .NotNull().WithMessage("Not null")
                .MinimumLength(2).WithMessage("Min length must be 1")
                .MaximumLength(200).WithMessage("Length must be less than 200");

            RuleFor(x => x.Desc)
                .NotNull().When(x => !x.isDeleted).WithMessage("If movie is active description cannot be null")
                .MaximumLength(800).WithMessage("Length must be less than 800");

            RuleFor(x => x.isDeleted).NotNull();

            RuleFor(x => x.Genre).NotNull().NotEmpty();

          
        }

    }
    }
