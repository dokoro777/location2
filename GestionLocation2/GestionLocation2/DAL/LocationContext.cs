using GestionLocation2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GestionLocation2.DAL
{
    public class LocationContext : DbContext
    {
        public LocationContext():base("name=LocationContext") {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Location> Locations { get; set; }
        //eviter de cree les tables 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }


    }
}