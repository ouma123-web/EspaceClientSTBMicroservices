

namespace STBEverywhere.Application.Extensions
{
    public static class CarteExtensions
    {
        public static IEnumerable<CarteDto> ToCarteDtoList(this IEnumerable<Carte> cartes)
        {
            return cartes.Select(carte => new CarteDto(
                Id: carte.Id.Value,
                ClientId: carte.ClientId.Value,
                NumCarte: carte.NumCarte,
                Solde: carte.Solde,
                CodeSecretCarte: carte.CodeSecretCarte,
                DateExpiration: carte.DateExpiration,
                Status: carte.Status,
                Type: carte.Type
                ));
        }

        public static CarteDto ToCarteDto(this Carte carte)
        {
            return DtoFromCarte(carte);
        }

        private static CarteDto DtoFromCarte(Carte carte)
        {
            return new CarteDto(
                 Id: carte.Id.Value,
                ClientId: carte.ClientId.Value,
                NumCarte: carte.NumCarte,
                Solde: carte.Solde,
                CodeSecretCarte: carte.CodeSecretCarte,
                DateExpiration: carte.DateExpiration,
                Status: carte.Status,
                Type: carte.Type
                );
        }

    }
}