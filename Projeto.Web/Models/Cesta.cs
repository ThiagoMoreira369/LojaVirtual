using System.Collections.Generic;

namespace Projeto.Web.Models
{
    public class Cesta
    {
        public decimal ValorTotal { get; set; }

        public List<ItemCesta> ItensCesta { get; set; }
    }
}