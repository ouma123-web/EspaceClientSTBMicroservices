using STBEverywhere.Domain.Abstractions;
using STBEverywhere.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Domain.Models
{
    public class Client : Aggregate<ClientId>
    {

        private readonly List<Compte> _comptes = new();
        public IReadOnlyList<Compte> Comptes => _comptes.AsReadOnly();



        [Key]
        //public int ClientId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

         public static Client Create(ClientId id, string nom, string prenom, string email)
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
        


    }
}
