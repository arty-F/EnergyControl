using System.Collections.Generic;

namespace EnergyControl.Domain.Entities
{
    public class ConsumptionObject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int SubsidiaryId { get; set; }
        public virtual Subsidiary Subsidiary { get; set; } = null!;
        public virtual List<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; } = new List<ElectricityMeasuringPoint>();
        public virtual List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; } = new List<ElectricitySupplyPoint>();
    }
}
