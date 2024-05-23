using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Events
{
    public record CompteCreatedEvent(Compte compte) : IDomainEvent;

}
