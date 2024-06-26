﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Comptes.Queries.GetComptesByOpération
{
   
   public record GetComptesByOpérationQuery(Guid OpérationId)
    : IQuery<GetComptesByOpérationResult>;

    public record GetComptesByOpérationResult(IEnumerable<CompteDto> Comptes);

}
