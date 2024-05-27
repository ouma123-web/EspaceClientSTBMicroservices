using STBEverywhere.Domain.Models;


namespace STBEverywhere.Application.Extensions
{
    public static class OpérationExtensions
    {

        public static IEnumerable<OpérationDto> ToOpérationDtoList(this IEnumerable<Opération> opérations)
        {
            return opérations.Select(opération => new OpérationDto(
                Id: opération.Id.Value,
                Visualisation: opération.Visualisation,
                Montant: opération.Montant,
                Type: opération.Type,
                Comptes: opération.Comptes.Select(o => new CompteDto(o.OpérationId.Value, o.ClientId.Value, o.CompteId.Value, o.NumCompte, o.Solde, o.DateOuverture, o.Type)).ToList()
                ));

        }

        public static OpérationDto ToOpérationDto(this Opération opération)
        {
            return DtoFromOpération(opération);
        }


        public static OpérationDto DtoFromOpération(Opération opération)
        {
            return new OpérationDto(
                Id: opération.Id.Value,
                Visualisation: opération.Visualisation,
                Montant: opération.Montant,
                Type: opération.Type,
                Comptes: opération.Comptes.Select(o => new CompteDto(o.OpérationId.Value, o.ClientId.Value, o.CompteId.Value, o.NumCompte, o.Solde, o.DateOuverture, o.Type)).ToList()

                );
        }
    }
}
