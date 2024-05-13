using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record CréditId
    {
        public Guid Value { get; }
        private CréditId(Guid value) => Value = value;
        public static CréditId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("CréditId cannot be empty.");
            }

            return new CréditId(value);
        }
    }
}
