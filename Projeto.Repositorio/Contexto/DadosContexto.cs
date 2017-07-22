using Projeto.Entidades;
using Projeto.Repositorio.Mapeamento;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projeto.Repositorio.Contexto
{
    public class DadosContexto : DbContext
    {
        public DadosContexto()
            : base(ConfigurationManager.
                 ConnectionStrings["loja"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MapeamentoProduto());
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
