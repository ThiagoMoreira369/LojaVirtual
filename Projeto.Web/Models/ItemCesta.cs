using Projeto.Entidades;

namespace Projeto.Web.Models
{
    public class ItemCesta
    {
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return Produto.Preco * Quantidade;
            }
        }
    }
}