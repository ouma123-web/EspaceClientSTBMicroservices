using STBEverywhere.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CompteId
    {
        public Guid Value { get; }
        private CompteId(Guid value) => Value = value;
        public static CompteId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CompteId cannot be empty.");
            }

            return new CompteId(value);
        }

    }
}
