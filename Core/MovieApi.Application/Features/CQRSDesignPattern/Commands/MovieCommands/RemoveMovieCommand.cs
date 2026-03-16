using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public RemoveMovieCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
