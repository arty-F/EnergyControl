using System;

namespace EnergyControl.Domain.Entities
{
    public class VoltageTransformer : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public TransformerType Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public float TransformationRatio { get; set; }
        //public int ElectricityMeasuringPointId { get; set; }
        public virtual ElectricityMeasuringPoint ElectricityMeasuringPoint { get; set; } = null!;
    }
}
