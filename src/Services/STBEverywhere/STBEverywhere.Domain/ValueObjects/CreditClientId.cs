using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CreditClientId
    {
        public Guid Value { get; }
        private CreditClientId(Guid value) => Value = value;
        public static CreditClientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CreditClientId cannot be empty.");
            }

            return new CreditClientId(value);
        }
    }
}
