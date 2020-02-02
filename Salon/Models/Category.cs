using System.Collections.Generic;

namespace Salon.Models
{
    public class Stylist
    {
        public int StylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StylistClient> Clients { get; set; }

        public Stylist()
        {
            this.Clients = new HashSet<StylistClient>();
        }
    }
}