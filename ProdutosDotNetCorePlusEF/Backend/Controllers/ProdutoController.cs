using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get() => await _context.Produtos.ToListAsync();

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            if (produto is null)
            {
                Console.WriteLine("Produto veio nulo");
                return BadRequest("Produto nulo");
            }
            Console.WriteLine($"Produto recebido: {produto.Nome}, {produto.Preco}, {produto.QuantidadeEmEstoque}");
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();
            _context.Entry(produto).Property(p => p.RowVersion).OriginalValue = produto.RowVersion;
            _context.Entry(produto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Conflito de concorrência detectado.");
            }
            return NoContent();
        }
    }
}
