using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CréditClientId
    {
        public Guid Value { get; }
        private CréditClientId(Guid value) => Value = value;
        public static CréditClientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CréditClientId cannot be empty.");
            }

            return new CréditClientId(value);
        }
    }
}
