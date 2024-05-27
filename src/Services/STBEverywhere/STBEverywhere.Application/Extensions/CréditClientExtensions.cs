

using STBEverywhere.Domain.ValueObjects;

namespace STBEverywhere.Application.Extensions
{
    public static class CréditClientExtensions
    {
        public static IEnumerable<CreditClientDto> ToCreditClientDtoList(this IEnumerable<ClientCredit> clientCredits)
        {
            return clientCredits.Select(clientCredit => new CreditClientDto(
                Id: clientCredit.Id.Value,
                ClientId: clientCredit.ClientId.Value,
                CreditId: clientCredit.CreditId.Value,
                DateDeblocage: clientCredit.DateDeblocage,
                MontantDebloquer: clientCredit.MontantDebloquer
                ));
        }

        public static CreditClientDto ToCreditClientDtoList(this ClientCredit clientCredit)
        {
            return DtoFromCreditClient(clientCredit);
        }

        private static CreditClientDto DtoFromCreditClient(ClientCredit clientCredit)
        {
            return new CreditClientDto(
                Id: clientCredit.Id.Value,
                ClientId: clientCredit.ClientId.Value,
                CreditId: clientCredit.CreditId.Value,
                DateDeblocage: clientCredit.DateDeblocage,
                MontantDebloquer: clientCredit.MontantDebloquer

                );
        }
    }

   
}
