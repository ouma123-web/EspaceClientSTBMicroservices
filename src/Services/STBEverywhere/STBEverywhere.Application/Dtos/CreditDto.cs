﻿using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Dtos
{
    public record CreditDto(
        string Code,
        decimal MaxMontant,
        string MaxDuree,
        CreditType Type,
        List<CreditClientDto> CreditClients);
}