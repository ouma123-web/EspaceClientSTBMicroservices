using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class Crédit : Entity<CréditId>

    {
        private readonly List<CréditClient> _créditclients = new();
        public IReadOnlyList<CréditClient> CréditClients => _créditclients.AsReadOnly();
        public string Code { get; set; }
        
        public CréditType Type { get; set; } = CréditType.Accepter;

        public Crédit(CréditType type, string code)
        {
            Type = type;
            Code = code;
            
        }
    }
}
