using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Extensions
{
    public static class CréditExtensions
    {

        public static IEnumerable<CreditDto> ToCreditDtoList(this IEnumerable<Credit> credits)
        {
            return credits.Select(credit => new CreditDto(
                Id: credit.Id.Value,
                Code: credit.Code,
                MaxMontant: credit.MaxMontant,
                MaxDuree: credit.MaxDuree,
                Type: credit.Type,
                Status: credit.Status,
                CreditClients: credit.CreditClients.Select(ccl => new CreditClientDto(ccl.Id.Value, ccl.ClientId.Value, ccl.CreditId.Value, ccl.DateDeblocage, ccl.MontantDebloquer)).ToList()
                ));
        }

        public static CreditDto ToCreditDto(this Credit credit)
        {
            return DteFromCredit(credit);
        }

        private static CreditDto DteFromCredit(Credit credit)
        {
            return new CreditDto(
                Id: credit.Id.Value,
                Code: credit.Code,
                MaxMontant: credit.MaxMontant,
                MaxDuree: credit.MaxDuree,
                Type: credit.Type,
                Status: credit.Status,
                CreditClients: credit.CreditClients.Select(ccl => new CreditClientDto(ccl.Id.Value, ccl.ClientId.Value, ccl.CreditId.Value, ccl.DateDeblocage, ccl.MontantDebloquer)).ToList()


                );
        }
    }
}
