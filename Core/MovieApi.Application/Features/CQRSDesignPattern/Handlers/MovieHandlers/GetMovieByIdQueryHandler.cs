using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResult;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync(query.Id);
            return new GetMovieByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status
            };
        }
    }
}
