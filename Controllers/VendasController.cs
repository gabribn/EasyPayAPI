using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Models;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Produto/{produtoId}")]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendasByProdutoId(string produtoId)
        {
            var vendas = await _context.Vendas
                .Where(v => v.Nome == produtoId)
                .ToListAsync();

            if (vendas == null || vendas.Count == 0)
            {
                return NotFound(new { message = "Nenhuma venda encontrada para este produto." });
            }

            return Ok(vendas);
        }
    }
}
