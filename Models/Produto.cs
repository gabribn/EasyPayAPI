﻿using System;

namespace ApiProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public string ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
