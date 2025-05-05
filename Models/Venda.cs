namespace ApiProdutos.Models
{
    public class Venda
    {
        public int Id { get; set; } // ID da venda
        public DateTime DataVenda { get; set; } // Data da venda
        public int ProdutoId { get; set; } // ID do produto
        public string Nome {  get; set; }
        public int Quantidade { get; set; } // Quantidade vendida
        public decimal ValorVendido { get; set; } // Valor total da venda
    }
}
