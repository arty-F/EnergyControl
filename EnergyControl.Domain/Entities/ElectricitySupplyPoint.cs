namespace EnergyControl.Domain.Entities
{
    public class ElectricitySupplyPoint : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float MaxPower { get; set; }
        public int ConsumptionObjectId { get; set; }
        public virtual ConsumptionObject ConsumptionObject { get; set; } = null!;
        public int SettlementMeterId { get; set; }
        public virtual SettlementMeter SettlementMeter { get; set; } = null!;
    }
}
