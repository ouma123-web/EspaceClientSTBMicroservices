using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Exceptions
{


    public class CreditNotFoundException : NotFoundException
    {
        public CreditNotFoundException(Guid id) : base("Credit", id)
        {
        }
    }
}
