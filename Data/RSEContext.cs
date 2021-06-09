using RSEBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RSEBack.data{

    public class RSEContext : DbContext{
        
        public RSEContext(DbContextOptions<RSEContext> opt) : base(opt){

        }

        public DbSet<Actualite> Actualites {get; set;}
        public DbSet<Impact> Impacts {get; set;}
        public DbSet<Partenaire> Partenaires {get; set;}
        public DbSet<Projet> Projets {get; set;}
        public DbSet<Suggestion> Suggestions {get; set;}
        public DbSet<Utilisateur> Utilisateurs {get; set;}
    }
}