using System.Collections.Generic;

namespace Salon.Models
{
    public class Client
    {
        public Client()
        {
            this.Stylists = new HashSet<StylistClient>();
        }

        public int ClientId { get; set; }
        public string Description { get; set; }

        public ICollection<StylistClient> Stylists { get; set; }
    }
}