using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMovieCommand command)
        {
            var movie = new Movie()
            {
                Title = command.Title,
                Description = command.Description,
                ReleaseDate = command.ReleaseDate,
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Duration = command.Duration,
                Rating = command.Rating,
                Status = command.Status
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
    }
}
