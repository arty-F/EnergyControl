using System;

namespace EnergyControl.Domain.Entities
{
    public class ElectricalEnergyMeter : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public ElectricalEnergyMeterType Type { get; set; }
        public DateTime VerificationDate { get; set; }
        public virtual ElectricityMeasuringPoint ElectricityMeasuringPoint { get; set; } = null!;
    }
}
