using EnergyControl.Application.Services.Queries;
using EnergyControl.Contracts.ConsumptionObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnergyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionObjectController : ControllerBase
    {
        private readonly ISender _mediator;

        public ConsumptionObjectController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ExpiredElectricalEnergyMeters")]
        public async Task<GetExpiredElectricalEnergyMetersResponse> GetExpiredElectricalEnergyMeters(
            GetExpiredPartRequest request)
        {
            var query = new GetExpiredElectricalEnergyMetersQuery(request);
            return await _mediator.Send(query);
        }

        [HttpPost("ExpiredPowerTransformers")]
        public async Task<GetExpiredPowerTransformersResponse> GetExpiredPowerTransformers(
            GetExpiredPartRequest request)
        {
            var query = new GetExpiredPowerTransformersQuery(request);
            return await _mediator.Send(query);
        }

        [HttpPost("ExpiredVoltageTransformers")]
        public async Task<GetExpiredVoltageTransformersResponse> GetExpiredVoltageTransformers(
            GetExpiredPartRequest request)
        {
            var query = new GetExpiredVoltageTransformersQuery(request);
            return await _mediator.Send(query);
        }
    }
}
