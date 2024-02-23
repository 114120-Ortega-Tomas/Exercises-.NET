using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial3.Resultados.ResultaodoFabricante;
using static Parcial3.Bussiness.FabricanteBusinnes.Querues.GetFabricantes;

namespace Parcial3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FabricanteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetFabricantes")]
        public async Task<ResultadoFabricante> GetFabricantes()
        {
            return await _mediator.Send(new Get());
        }

    }
}
