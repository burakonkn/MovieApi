using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CastList()
        {
            var value = await _mediator.Send(new GetCastQuery());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand request)
        {
            await _mediator.Send(request);
            return Ok("Oyuncu ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(Guid id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Oyuncu silme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand request)
        {
            await _mediator.Send(request);
            return Ok("Oyuncu güncelleme işlemi başarılı.");
        }

        [HttpGet("GetCast")]
        public async Task<IActionResult> GetCast(Guid id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }
    }
}
