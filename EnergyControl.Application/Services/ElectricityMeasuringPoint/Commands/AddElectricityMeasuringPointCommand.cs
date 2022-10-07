using EnergyControl.Contracts.ElectricityMeasuringPoint;
using MediatR;

namespace EnergyControl.Application.Services.Commands
{
    public record AddElectricityMeasuringPointCommand(
        AddElectricityMeasuringPointRequest Request) : IRequest<AddElectricityMeasuringPointResponse>;
}
