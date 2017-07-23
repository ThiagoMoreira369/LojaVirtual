namespace Projeto.Repositorio.Migrations
{
    using Projeto.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Repositorio.Contexto.DadosContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Projeto.Repositorio.Contexto.DadosContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto()
            { IdProduto = 1, Nome = "Notebook", Preco = 2000M, Foto = "notebook.jpg" });

            lista.Add(new Produto()
            { IdProduto = 2, Nome = "Computador", Preco = 2500M, Foto = "computador.jpg" });

            lista.Add(new Produto()
            { IdProduto = 3, Nome = "Mochila", Preco = 40M, Foto = "mochila.jpg" });

            lista.Add(new Produto()
            { IdProduto = 4, Nome = "Mouse", Preco = 100M, Foto = "mouse.jpg" });

            lista.Add(new Produto()
            { IdProduto = 5, Nome = "Notebook", Preco = 3000M, Foto = "notebook.jpg" });

            lista.Add(new Produto()
            { IdProduto = 6, Nome = "Pendrive", Preco = 2800M, Foto = "pendrive.jpg" });

            lista.Add(new Produto()
            { IdProduto = 7, Nome = "Playstation", Preco = 400M, Foto = "playstation.jpg" });

            lista.Add(new Produto()
            { IdProduto = 8, Nome = "XBox", Preco = 150M, Foto = "xbox.jpg" });

            foreach (Produto p in lista)
            {
                context.Produto.AddOrUpdate(p);
                context.SaveChanges();
            }
        }
    }
}
