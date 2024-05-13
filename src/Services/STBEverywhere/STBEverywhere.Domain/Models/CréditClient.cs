using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class CréditClient : Entity<CréditClientId>
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int CréditId { get; set; }
        public Crédit Credit { get; set; }

    }
}
