using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CastList()
        {
            var value = _mediator.Send(new GetCastQuery());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCast(CreateCastCommand request)
        {
            _mediator.Send(request);
            return Ok("Oyuncu ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCast(Guid id)
        {
            _mediator.Send(new RemoveCastCommand(id));
            return Ok("Oyuncu silme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCast(UpdateCastCommand request)
        {
            _mediator.Send(request);
            return Ok("Oyuncu güncelleme işlemi başarılı.");
        }

        [HttpGet("GetCast")]
        public IActionResult GetCast(Guid id)
        {
            var value = _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
    }
}
