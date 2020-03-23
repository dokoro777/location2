using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLocation2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int Numpiece { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        [JsonIgnore]
        public virtual List<Location>  Locations { get; set; }
    
    }
}