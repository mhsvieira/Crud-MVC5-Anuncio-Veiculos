using AnuncioDeVeiculo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AnuncioDeVeiculo.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("BDStrConn") { }  // construtor estende a execução do	construtor da classe base

        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}