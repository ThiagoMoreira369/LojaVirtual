using Projeto.Entidades;
using Projeto.Repositorio.Persistencia;
using Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Projeto.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto/Consulta
        public ActionResult Consulta()
        {
            ProdutoRepositorio rep = new ProdutoRepositorio();
            List<Produto> lista = rep.ListarTodos();

            return View(lista);
        }

        // GET: Produto/Cesta
        public ActionResult Cesta()
        {
            return View();
        }

        public ActionResult AdicionarItem(int id)
        {
            try
            {
                ProdutoRepositorio rep = new ProdutoRepositorio();
                Cesta c = new Cesta();

                if (Session["cesta"] != null)
                {
                    c = (Cesta)Session["cesta"];
                }
                else
                {
                    c = new Cesta();
                    c.ItensCesta = new List<ItemCesta>();
                }

                ItemCesta itemExistente = c.ItensCesta
                                            .Where(i => i.Produto.IdProduto == id)
                                            .FirstOrDefault();

                if (itemExistente != null)
                {
                    itemExistente.Quantidade++;
                }
                else
                {
                    ItemCesta item = new ItemCesta();
                    item.Quantidade = 1;
                    item.Produto = rep.ObterPorId(id);
                    c.ItensCesta.Add(item);
                }

                c.ValorTotal = c.ItensCesta.Sum(i => i.ValorTotal);

                Session.Add("cesta", c);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View("Cesta");
        }

        public ActionResult AumentarQuantidade(int id)
        {
            Cesta c = (Cesta)Session["cesta"];
            ItemCesta item = c.ItensCesta.Where(i => i.Produto.IdProduto == id)
                .FirstOrDefault();

            item.Quantidade++;

            c.ValorTotal = c.ItensCesta.Sum(i => i.ValorTotal);

            return View("Cesta");
        }

        public ActionResult DiminuirQuantidade(int id)
        {
            Cesta c = (Cesta)Session["cesta"];
            ItemCesta item = c.ItensCesta.Where(i => i.Produto.IdProduto == id)
                .FirstOrDefault();

            if (item.Quantidade > 1)
            {
                item.Quantidade--;
            }

            c.ValorTotal = c.ItensCesta.Sum(i => i.ValorTotal);

            return View("Cesta");
        }

        public ActionResult ExcluirItem(int id)
        {
            Cesta c = (Cesta)Session["cesta"];

            c.ItensCesta.RemoveAll(i => i.Produto.IdProduto == id);

            c.ValorTotal = c.ItensCesta.Sum(i => i.ValorTotal);

            return View("Cesta");
        }

        public ActionResult ExcluirCesta()
        {
            Session.Remove("cesta");

            return View("Cesta");
        }
    }
}