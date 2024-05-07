using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Events
{
    public record ClientUpdateEvent(Client Client) : IDomainEvent;
    
}
