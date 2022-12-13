using System;

namespace EnergyControl.Contracts.ConsumptionObject
{
    public record ExpiredElectricalEnergyMeter(
        string Number,
        int Type,
        DateTime VerificationDate);

    public record GetExpiredElectricalEnergyMetersResponse(
        ExpiredElectricalEnergyMeter[] ExpiredElectricalEnergyMeters);
}
