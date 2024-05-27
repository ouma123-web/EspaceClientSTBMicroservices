using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Events
{
    internal class CreditUpdatedEvent(Credit Credit) : IDomainEvent;

}
