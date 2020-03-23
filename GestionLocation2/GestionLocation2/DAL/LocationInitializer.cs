using GestionLocation2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionLocation2.DAL
{
    //permet de genere la base et verifier le model
    public class LocationInitializer : DropCreateDatabaseIfModelChanges<LocationContext>
    {
        
        //
        protected override void Seed(LocationContext context)
        {
            var vehicules = new List<Vehicule>
            {
                new Vehicule{Couleur="jaune", Matricule="DKR667", Marque="BMW", Modele="X6",PrixJour=50000 },
                 new Vehicule{Couleur="rouge", Matricule="DKR422", Marque="Primera", Modele="xx",PrixJour=250000 },
                  new Vehicule{Couleur="noir", Matricule="DKR368", Marque="Rav4", Modele="X4",PrixJour=30000 },
                   new Vehicule{Couleur="gris", Matricule="DKR132", Marque="BMW", Modele="X6",PrixJour=50000 },
                    new Vehicule{Couleur="vert", Matricule="DKR887", Marque="Deep", Modele="XX4",PrixJour=45000 }
            };
            //sa cree des objet et ajoute dans la bd
            vehicules.ForEach(v => context.Vehicules.Add(v));
            context.SaveChanges();

            

        }
    }
}