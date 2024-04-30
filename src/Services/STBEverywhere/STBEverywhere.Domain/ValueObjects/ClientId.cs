using STBEverywhere.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record ClientId
    {
        public Guid Value { get; }
        private ClientId(Guid value) => Value = value;
        public static ClientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("ClientId cannot be empty.");
            }

            return new ClientId(value);
        }
    }
}
