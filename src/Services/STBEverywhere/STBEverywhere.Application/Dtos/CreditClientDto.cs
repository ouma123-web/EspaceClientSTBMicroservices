using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record CreditClientDto(
        Guid Id,
        Guid ClientId,
        Guid CreditId,
        
        string DateDeblocage,
        decimal MontantDebloquer
        );
}
