namespace STBEverywhere.Domain.Models
{
    public class Client : Aggregate<ClientId>
    {

        //public List<Carte> cartes = new();


        private readonly List<Carte> _cartes = new();
        public IReadOnlyList<Carte> cartes => _cartes.AsReadOnly();



        //private readonly List<Carte> _cartes = new();
        //public IEnumerable<Carte> Cartes => _cartes.AsEnumerable();


        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();




       internal Client(ClientId id, string nom, string prenom, string email)
        {
            Id = ClientId.Of(Guid.NewGuid()); ;
            Nom = nom;
            Prenom = prenom;
            Email = email;

        }



        //public int ClientId { get; set; }

        public Guid CompteId { get; set; } // Propriété pour l'identifiant du compte
        public Guid CarteId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        /* public static Client Create(ClientId id, string nom, string prenom, string email)
         {
         var client = new Client
         {
             Id = id,
             Nom = nom,
             Prenom = prenom,
             Email = email
         };

         return client;
         }
        */


        public void Update(string nom, string prenom, string email)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;

            AddDomainEvent(new ClientUpdateEvent(this));
        }


        public string ConsulterClient()
        {
            return $"Nom: {Nom}, Prénom: {Prenom}, Email: {Email}, CompteId: {CompteId}, CarteId: {CarteId}";
        }
    }
}
