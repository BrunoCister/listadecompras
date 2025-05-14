using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
