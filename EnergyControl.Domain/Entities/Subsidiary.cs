namespace EnergyControl.Domain.Entities
{
    public class Subsidiary : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = null!;
    }
}
