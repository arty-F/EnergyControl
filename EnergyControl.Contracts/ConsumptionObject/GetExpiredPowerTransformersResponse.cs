using System;

namespace EnergyControl.Contracts.ConsumptionObject
{
    public record ExpiredPowerTransformers(
        string Number,
        int Type,
        DateTime VerificationDate,
        float TransformationRatio);

    public record GetExpiredPowerTransformersResponse(
        ExpiredPowerTransformers[] ExpiredPowerTranformers);
}
