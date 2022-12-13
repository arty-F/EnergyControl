using EnergyControl.Contracts.ConsumptionObject;
using MediatR;

namespace EnergyControl.Application.Services.Queries
{
    public record GetExpiredElectricalEnergyMetersQuery(
        GetExpiredPartRequest Request) : IRequest<GetExpiredElectricalEnergyMetersResponse>;
}
