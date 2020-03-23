using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionLocation2.Models
{
    public class Location
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Nbjour { get; set; }
        public int Montantr { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public virtual Vehicule Vehicule { get; set; }
    }
}