using System;

namespace EnergyControl.Contracts.ElectricityMeasuringPoint
{
    public record AddElectricityMeasuringPointRequest(
        string Name,
        string ElectricalEnergyMeterNumber,
        int ElectricalEnergyMeterType,
        DateTime ElectricalEnergyMeterVerificationDate,
        string PowerTransformerNumber,
        int PowerTransformerType,
        DateTime PowerTransformerVerificationDate,
        string VoltageTransformerNumber,
        int VoltageTransformerType,
        DateTime VoltageTransformerVerificationDate);
}
