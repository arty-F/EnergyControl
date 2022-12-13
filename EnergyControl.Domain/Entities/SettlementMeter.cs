using System;
using System.Collections.Generic;

namespace EnergyControl.Domain.Entities
{
    public class SettlementMeter : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual List<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; set; } = new List<ElectricityMeasuringPoint>();
        public virtual List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; } = new List<ElectricitySupplyPoint>();
    }
}
