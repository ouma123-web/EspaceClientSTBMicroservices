


namespace STBEverywhere.Domain.Models
{
    public class Compte : Aggregate<CompteId>
    {



        public OpérationId OpérationId { get; set; }
        public ClientId ClientId { get; set; }
        public string NumCompte { get; set; } = string.Empty;
        public decimal Solde { get; set; }
        public DateTime DateOuverture { get; set; }
        public CompteType Type { get; private set; } = CompteType.CompteCheque;

        public static Compte Create(CompteId compteId, OpérationId opérationId, ClientId clientId, string numCompte, decimal solde, DateTime dateouverture)
        {
            var compte = new Compte
            {
                ClientId = clientId,
                Id = compteId,
                OpérationId = opérationId,
                NumCompte = numCompte,
                Solde = solde,
                DateOuverture = dateouverture,
                Type = CompteType.CompteEpargne           };

           compte.AddDomainEvent(new CompteCreatedEvent(compte));

            return compte;

        }

       



    }

}
