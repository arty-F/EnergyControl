using EnergyControl.Application.Services.Queries;
using EnergyControl.Contracts.SettlementMeter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnergyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementMeterController : ControllerBase
    {
        private readonly ISender _mediator;

        public SettlementMeterController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<GetSettlementMeterByYearResponse> GetByYear(GetSettlementMeterByYearRequest request)
        {
            var query = new GetSettlementMeterByYearQuery(request);
            return await _mediator.Send(query);
        }
    }
}
