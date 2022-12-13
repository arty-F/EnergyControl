using EnergyControl.Contracts.ConsumptionObject;
using MediatR;

namespace EnergyControl.Application.Services.Queries
{
    public record GetExpiredVoltageTransformersQuery(
        GetExpiredPartRequest Request) : IRequest<GetExpiredVoltageTransformersResponse>;
}
