using EnergyControl.Contracts.SettlementMeter;
using MediatR;

namespace EnergyControl.Application.Services.Queries
{
    public record GetSettlementMeterByYearQuery(
        GetSettlementMeterByYearRequest Request) : IRequest<GetSettlementMeterByYearResponse>;
}
