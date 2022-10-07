using EnergyControl.Application.Services.Commands;
using EnergyControl.Contracts.ElectricityMeasuringPoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnergyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityMeasuringPointController : ControllerBase
    {
        private readonly ISender _mediator;

        public ElectricityMeasuringPointController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AddElectricityMeasuringPointResponse> AddNewPoint(AddElectricityMeasuringPointRequest request)
        {
            var query = new AddElectricityMeasuringPointCommand(request);
            return await _mediator.Send(query);
        }
    }
}
