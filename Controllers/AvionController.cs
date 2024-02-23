using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3.Resultados.ResultadoAvion;
using static Parcial3.Bussiness.AvionesBusiness.Commans.UpdateAvion;
using static Parcial3.Bussiness.AvionesBusiness.Querys.Get;

namespace Parcial3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AvionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAviones")]
        public async Task<ResultadoAvion> GetAviones()
        {
            return await _mediator.Send(new GetAviones());
        }
        [HttpPut]
        [Route("UpdateAvion")]
        public async Task<ResultadoAvion> UpdateAvion([FromBody] Put put)
        {
            return await _mediator.Send(put);
        }
    }
}
