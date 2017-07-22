using Projeto.Entidades;
using Projeto.Repositorio.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projeto.Repositorio.Persistencia
{
    public class ProdutoRepositorio
    {
        public void Inserir(Produto p)
        {
            using (DadosContexto d = new DadosContexto())
            {
                d.Entry(p).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Atualizar(Produto p)
        {
            using (DadosContexto d = new DadosContexto())
            {
                d.Entry(p).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public void Excluir(Produto p)
        {
            using (DadosContexto d = new DadosContexto())
            {
                d.Entry(p).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<Produto> ListarTodos()
        {
            using (DadosContexto d = new DadosContexto())
            {
                return d.Produto.ToList();
            }
        }

        public Produto ObterPorId(int idProduto)
        {
            using (DadosContexto d = new DadosContexto())
            {
                return d.Produto.Find(idProduto);
            }
        }
    }
}
