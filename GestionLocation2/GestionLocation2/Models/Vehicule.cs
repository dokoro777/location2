using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionLocation2.Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Couleur { get; set; }
        public int PrixJour { get; set; }
        [JsonIgnore]
        public virtual List<Location> Locations { get; set; }
    }
}