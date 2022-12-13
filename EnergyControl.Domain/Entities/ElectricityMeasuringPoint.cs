using System.Collections.Generic;

namespace EnergyControl.Domain.Entities
{
    public class ElectricityMeasuringPoint : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ConsumptionObjectId { get; set; }
        public virtual ConsumptionObject ConsumptionObject { get; set; } = null!;
        public int? SettlementMeterId { get; set; }
        public virtual SettlementMeter SettlementMeter { get; set; } = null!;
        public int ElectricalEnergyMeterId { get; set; }
        public virtual ElectricalEnergyMeter ElectricalEnergyMeter { get; set; } = null!;
        public int PowerTransformerId { get; set; }
        public virtual PowerTransformer PowerTransformer { get; set; } = null!;
        public int VoltageTransformerId { get; set; }
        public virtual VoltageTransformer VoltageTransformer { get; set; } = null!;
    }
}
