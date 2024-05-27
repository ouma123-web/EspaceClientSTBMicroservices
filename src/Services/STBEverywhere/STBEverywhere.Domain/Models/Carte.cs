using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;


namespace STBEverywhere.Domain.Models
{
    public class Carte : Entity<CarteId>
    {
        public ClientId ClientId { get; set; }
       
        public string NumCarte { get; set; } = null!;
        public decimal Solde { get; set; }
        public decimal CodeSecretCarte { get; set; }
        public DateOnly DateExpiration { get; set; }
        public CarteStatus Status { get; private set; } = CarteStatus.Bloqué;
        public CarteType Type { get; private set; } = CarteType.CarteElectronique;

       


    }
}
