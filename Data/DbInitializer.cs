using System;
using System.Collections.Generic;
using System.Linq;
using ApiProdutos.Models;

namespace ApiProdutos.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {

            if (context.Produtos.Any())
            {
                context.Produtos.RemoveRange(context.Produtos);
                context.SaveChanges();
            }

            if (context.Vendas.Any())
            {
                context.Vendas.RemoveRange(context.Vendas);
                context.SaveChanges();
            }

            var produtos = new List<Produto>
            {
                new Produto { Nome = "Porção de Batata Frita", Preco = 25.00m, Categoria = "Petiscos", Estoque = 30, ImagemUrl = "data:image/jpeg;base64,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", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Cerveja Artesanal", Preco = 15.00m, Categoria = "Bebidas", Estoque = 58, ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbZVhfepWK5EcPPT1AOVEmFXWg-AZ4QS46TA&s", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Caipirinha", Preco = 18.00m, Categoria = "Bebidas", Estoque = 50, ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3-8MYFOcEcGQPBlrQS1l_2qsldUmbnv3eqg&s", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Espetinho de Carne", Preco = 12.00m, Categoria = "Petiscos", Estoque = 20, ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMG88tFZbUKpmjS8xoGaesRmCMzPRyTuFk2g&s", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Coxinha", Preco = 10.00m, Categoria = "Salgados", Estoque = 8, ImagemUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTUh_MAwGDys4wQt6-IOxXF0yfYwzqJk-08g&s", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Caldo de Cana", Preco = 8.00m, Categoria = "Bebidas", Estoque = 78, ImagemUrl = "https://vitat.com.br/bkt/busca-de-alimentos/190-caldo-de-cana.jpg?ims=fit-in/404x260/filters:quality(80):format(webpp)", DataAlteracao = DateTime.Now },
                new Produto { Nome = "Soda Limonada", Preco = 6.00m, Categoria = "Bebidas", Estoque = 90, ImagemUrl = "https://www.imigrantesbebidas.com.br/bebida/images/products/full/1932-refrigerante-soda-limonada-antarctica-lata-350ml.jpg", DataAlteracao = DateTime.Now }
            };

            context.Produtos.AddRange(produtos);

            var vendas = new List<Venda>
            {
                // Vendas para o Produto 1 (Porção de Batata Frita)
                new Venda
                {
                    ProdutoId = 43,
                    Quantidade = 3,
                    Nome = "Porção de Batata Frita",
                    DataVenda = new DateTime(2025, 5, 1, 12, 30, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 43,
                    Quantidade = 3,
                    Nome = "Porção de Batata Frita",
                    DataVenda = new DateTime(2025, 5, 2, 12, 30, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 43,
                    Nome = "Porção de Batata Frita",
                    Quantidade = 3,
                    DataVenda = new DateTime(2025, 5, 3, 12, 30, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 43,
                    Nome = "Porção de Batata Frita",
                    Quantidade = 3,
                    DataVenda = new DateTime(2025, 5, 4, 12, 30, 0),
                    ValorVendido  = 75.00m
                },

                // Vendas para o Produto 2 (Cerveja Artesanal)
                new Venda
                {
                    ProdutoId = 44,
                    Nome =  "Cerveja Artesanal",
                    Quantidade = 5,
                    DataVenda = new DateTime(2025, 5, 2, 14, 0, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 44,
                    Nome =  "Cerveja Artesanal",
                    Quantidade = 5,
                    DataVenda = new DateTime(2025, 5, 3, 14, 0, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 44,
                    Nome =  "Cerveja Artesanal" ,
                    Quantidade = 5,
                    DataVenda = new DateTime(2025, 5, 4, 14, 0, 0),
                    ValorVendido  = 75.00m
                },
                new Venda
                {
                    ProdutoId = 44,
                    Nome =  "Cerveja Artesanal",
                    Quantidade = 5,
                    DataVenda = new DateTime(2025, 5, 5, 14, 0, 0),
                    ValorVendido  = 75.00m
                },

                // Vendas para o Produto 3 (Caipirinha)
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 3, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 3, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 3, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 4, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 4, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Quantidade = 2,
                    Nome = "Caipirinha",
                    DataVenda = new DateTime(2025, 5, 5, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Nome = "Caipirinha",
                    Quantidade = 2,
                    DataVenda = new DateTime(2025, 5, 6, 18, 45, 0),
                    ValorVendido  = 36.00m
                },
                new Venda
                {
                    ProdutoId = 45,
                    Nome = "Caipirinha",
                    Quantidade = 2,
                    DataVenda = new DateTime(2025, 5, 6, 18, 45, 0),
                    ValorVendido  = 36.00m
                },new Venda
                {
                    ProdutoId = 45,
                    Nome = "Caipirinha",
                    Quantidade = 2,
                    DataVenda = new DateTime(2025, 5, 6, 18, 45, 0),
                    ValorVendido  = 36.00m
                },

                // Vendas para o Produto 4 (Espetinho de Carne)
                new Venda
                {
                    ProdutoId = 46,
                    Nome = "Espetinho de Carne",
                    Quantidade = 4,
                    DataVenda = new DateTime(2025, 5, 4, 20, 15, 0),
                    ValorVendido  = 48.00m
                },
                new Venda
                {
                    ProdutoId = 46,
                    Nome = "Espetinho de Carne",
                    Quantidade = 4,
                    DataVenda = new DateTime(2025, 5, 5, 20, 15, 0),
                    ValorVendido  = 48.00m
                },
                new Venda
                {
                    ProdutoId = 46,
                    Nome ="Espetinho de Carne" ,
                    Quantidade = 4,
                    DataVenda = new DateTime(2025, 5, 6, 20, 15, 0),
                    ValorVendido  = 48.00m
                },
                new Venda
                {
                    ProdutoId = 46,
                    Nome = "Espetinho de Carne",
                    Quantidade = 4,
                    DataVenda = new DateTime(2025, 5, 7, 20, 15, 0),
                    ValorVendido  = 48.00m
                },

                // Vendas para o Produto 5 (Coxinha)
                new Venda
                {
                    ProdutoId = 47,
                    Nome = "Coxinha",
                    Quantidade = 6,
                    DataVenda = new DateTime(2025, 5, 5, 10, 30, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 47,
                    Quantidade = 6,
                    Nome = "Coxinha",
                    DataVenda = new DateTime(2025, 5, 6, 10, 30, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 47,
                    Nome = "Coxinha",
                    Quantidade = 6,
                    DataVenda = new DateTime(2025, 5, 7, 10, 30, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 47,
                    Nome = "Coxinha",
                    Quantidade = 6,
                    DataVenda = new DateTime(2025, 5, 8, 10, 30, 0),
                    ValorVendido  = 60.00m
                },

                // Vendas para o Produto 6 (Caldo de Cana)
                new Venda
                {
                    ProdutoId = 48,
                    Quantidade = 8,
                    Nome = "Caldo de Cana",
                    DataVenda = new DateTime(2025, 5, 6, 15, 0, 0),
                    ValorVendido  = 64.00m
                },
                new Venda
                {
                    ProdutoId = 48,
                    Quantidade = 8,
                    Nome = "Caldo de Cana",
                    DataVenda = new DateTime(2025, 5, 7, 15, 0, 0),
                    ValorVendido  = 64.00m
                },
                new Venda
                {
                    ProdutoId = 48,
                    Nome = "Caldo de Cana",
                    Quantidade = 8,
                    DataVenda = new DateTime(2025, 5, 8, 15, 0, 0),
                    ValorVendido  = 64.00m
                },
                new Venda
                {
                    ProdutoId = 48,
                    Quantidade = 8,
                    Nome = "Caldo de Cana",
                    DataVenda = new DateTime(2025, 5, 9, 15, 0, 0),
                    ValorVendido  = 64.00m
                },

                // Vendas para o Produto 7 (Soda Limonada)
                new Venda
                {
                    ProdutoId = 49,
                    Nome = "Soda Limonada",
                    Quantidade = 10,
                    DataVenda = new DateTime(2025, 5, 7, 11, 15, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 49,
                    Quantidade = 10,
                    Nome = "Soda Limonada",
                    DataVenda = new DateTime(2025, 5, 8, 11, 15, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 49,
                    Nome = "Soda Limonada",
                    Quantidade = 10,
                    DataVenda = new DateTime(2025, 5, 9, 11, 15, 0),
                    ValorVendido  = 60.00m
                },
                new Venda
                {
                    ProdutoId = 49,
                    Quantidade = 10,
                    Nome = "Soda Limonada",
                    DataVenda = new DateTime(2025, 5, 10, 11, 15, 0),
                    ValorVendido  = 60.00m
                }
            };


            context.Vendas.AddRange(vendas);

            context.SaveChanges();
        }
    }
}
