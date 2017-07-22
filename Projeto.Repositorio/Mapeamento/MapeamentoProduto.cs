using Projeto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositorio.Mapeamento
{
    public class MapeamentoProduto
        :EntityTypeConfiguration<Produto>
    {
        public MapeamentoProduto()
        {
            HasKey(p => p.IdProduto);
        }
    }
}
