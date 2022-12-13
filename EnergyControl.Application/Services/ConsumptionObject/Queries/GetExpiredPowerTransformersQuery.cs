using EnergyControl.Contracts.ConsumptionObject;
using MediatR;

namespace EnergyControl.Application.Services.Queries
{
    public record GetExpiredPowerTransformersQuery(
        GetExpiredPartRequest Request) : IRequest<GetExpiredPowerTransformersResponse>;
}
