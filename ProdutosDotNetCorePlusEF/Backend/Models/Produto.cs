using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; } = string.Empty;
        
        public decimal Preco { get; set; }
        
        public int QuantidadeEmEstoque { get; set; }
        
        [Timestamp]
        public byte[]? RowVersion { get; set; } = [];
    }
}