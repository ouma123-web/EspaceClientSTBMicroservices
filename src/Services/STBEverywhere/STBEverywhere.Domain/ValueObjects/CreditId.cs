using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CreditId
    {
        public Guid Value { get; }
        private CreditId(Guid value) => Value = value;
        public static CreditId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CreditId cannot be empty.");
            }

            return new CreditId(value);
        }
    }
}
