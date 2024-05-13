using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.ValueObjects
{
    public record OpérationId
    {

        public Guid Value { get; }
        private OpérationId(Guid value) => Value = value;
        public static OpérationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("OpérationId cannot be empty.");
            }

            return new OpérationId(value);
        }
    }
}
