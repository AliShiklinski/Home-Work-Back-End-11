using CinemaApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie> 
    {
        public void Configure(EntityTypeBuilder<Movie> builder) 
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Description).HasMaxLength(800);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x=>x.Genres).IsRequired();
            builder.Property(x=>x.ReleaseDate).IsRequired();
            builder.Property(x=>x.Rating).IsRequired();
            
        }

    }
    
}
