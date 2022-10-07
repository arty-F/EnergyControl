using System.Collections.Generic;

namespace EnergyControl.Domain.Entities
{
    public class Organization : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public virtual List<Subsidiary> Subsidiaries { get; set; } = new List<Subsidiary>();
    }
}
