using System;

namespace EnergyControl.Contracts.ConsumptionObject
{
    public record ExpiredVoltageTransformers(
        string Number,
        int Type,
        DateTime VerificationDate,
        float TransformationRatio);

    public record GetExpiredVoltageTransformersResponse(
        ExpiredVoltageTransformers[] ExpiredVoltageTranformers);
}
